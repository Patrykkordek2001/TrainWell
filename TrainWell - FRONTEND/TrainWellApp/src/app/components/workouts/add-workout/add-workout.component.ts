import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ExerciseDto } from 'src/app/Models/exercises/ExerciseDto';
import { ExercisePreview } from 'src/app/Models/exercises/ExercisePreview';
import { WorkoutDto } from 'src/app/Models/workouts/WorkoutDto';
import { DateSharingService } from 'src/app/services/date-sharing.service';
import { ExercisesService } from 'src/app/services/workouts/exercises.service';
import { WorkoutsService } from 'src/app/services/workouts/workouts.service';

@Component({
  selector: 'app-add-workout',
  templateUrl: './add-workout.component.html',
  styleUrls: ['./add-workout.component.css'],
})
export class AddWorkoutComponent implements OnInit {
  addingExercise: boolean = false;
  addingExerciseToList: boolean = false;
  exercises: ExercisePreview[] = [];

  trainingForm = this.formBuilder.group({
    title: ['', Validators.required],
    date: [new Date(), Validators.required],
    nameOfExercise: [''],
    exercisesWorkout: this.formBuilder.array([
      this.formBuilder.group({
        exerciseId: ['', Validators.required],
        exerciseSets: this.formBuilder.array([
          this.formBuilder.group({
            repetitions: ['', Validators.required],
            weight: ['', Validators.required],
          }),
        ]),
      }),
    ]),
  });

  constructor(
    private formBuilder: FormBuilder,
    private exerciseService: ExercisesService,
    private toastrService: ToastrService,
    private dateSharingService: DateSharingService,
    private workoutsService: WorkoutsService,
  ) {}

  // ngOnInit(): void {
  //     this.trainingForm.valueChanges.subscribe(x => console.log(x));
  // }

  get exercisesWorkout() {
    return this.trainingForm.get('exercisesWorkout') as FormArray;
  }

  get exerciseControls() {
    return (this.trainingForm.get('exercisesWorkout') as FormArray).controls;
  }

  get date() {
    return this.trainingForm.get('date')?.value;
  }

  getExerciseSets(exerciseIndex: number) {
    return (
      this.exerciseControls[exerciseIndex].get('exerciseSets') as FormArray
    ).controls;
  }

  addSet(exerciseIndex: number): void {
    const exerciseSet = this.exercisesWorkout
      .at(exerciseIndex)
      .get('exerciseSets') as FormArray;
    exerciseSet.push(
      this.formBuilder.group({
        repetitions: ['', Validators.required],
        weight: ['', Validators.required],
      })
    );
  }

  removeSet(exerciseIndex: number, setIndex: number): void {
    const exerciseSet = this.exercisesWorkout
      .at(exerciseIndex)
      .get('exerciseSets') as FormArray;
    exerciseSet.removeAt(setIndex);
  }

  removeExercise(exerciseIndex: number): void {
    this.exercisesWorkout.removeAt(exerciseIndex);
  }

  addExercise(): void {
    this.exercisesWorkout.push(
      this.formBuilder.group({
        exerciseId: ['', Validators.required],
        exerciseSets: this.formBuilder.array([]),
      })
    );
  }
  

  submit() {
    if (this.trainingForm.valid) {
      const workoutData = this.trainingForm.value as unknown as WorkoutDto;
      console.log(workoutData);
      this.workoutsService.addWorkout(workoutData).subscribe(
        response => {
          console.log('Success:', response);
          // Dodaj kod obsługi sukcesu, jeśli to konieczne
        },
        error => {
          console.error('Error:', error);
          // Dodaj kod obsługi błędu, jeśli to konieczne
        }
      );
    }
    
  }

  onSubmit() {}

  ngOnInit(): void {
    this.fetchExercises();
    this.setDateFromService();
    this.trainingForm.valueChanges.subscribe((x) => console.log(x));
    console.log(this.addingExercise);
  }

  private setDateFromService() {
    const selectedDate = this.dateSharingService.getSelectedDate();

    this.date?.setDate(selectedDate.getDate());
  }

  addExerciseBool() {
    this.addingExercise = true;
  }
  cancelAddingExercise() {
    this.addingExercise = false;
  }

  addExerciseToList() {
    this.addingExerciseToList = true;
  }
  get nameOfExercise() {
    return this.trainingForm.get('nameOfExercise')?.value;
  }

  addExerciseToListSubmit() {
    let exercise: ExerciseDto = {
      name: this.nameOfExercise as string,
    };
    this.exerciseService.addExercise(exercise).subscribe(
      (response) => {
        this.exercises.push(response);
        this.toastrService.success('Ćwiczenie zostało dodane do listy');
        this.cancelAddingExerciseToList();
      },
      (error) => {
        console.error('Błąd podczas dodawania ćwiczenia:', error);
        this.toastrService.error('Wystąpił błąd podczas dodawania ćwiczenia.');
      }
    );
  }

  cancelAddingExerciseToList() {
    this.addingExerciseToList = false;
  }

  fetchExercises() {
    this.exerciseService.getAllExercises().subscribe(
      (exercisesFromDatabase) => {
        this.exercises = exercisesFromDatabase;
      },
      (error) => {
        console.log(error);
        console.log(error.text);
        console.log(error.error.text);
        this.toastrService.warning(error.error.text);
      }
    );
  }
}
