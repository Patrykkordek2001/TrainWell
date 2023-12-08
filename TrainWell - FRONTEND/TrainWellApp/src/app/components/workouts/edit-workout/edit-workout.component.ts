import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DateSharingService } from 'src/app/services/date-sharing.service';
import { ExercisesService } from 'src/app/services/workouts/exercises.service';
import { WorkoutsService } from 'src/app/services/workouts/workouts.service';
import { ExercisePreview } from 'src/app/Models/exercises/ExercisePreview';
import { ExerciseDto } from 'src/app/Models/exercises/ExerciseDto';
import { WorkoutDto } from 'src/app/Models/workouts/WorkoutDto';
import { WorkoutPreview } from 'src/app/Models/workouts/WorkoutPreview';
import { WorkoutPreviewWithDetails } from 'src/app/Models/workouts/WorkoutPreviewWithDetails';

@Component({
  selector: 'app-edit-workout',
  templateUrl: './edit-workout.component.html',
  styleUrls: ['./edit-workout.component.css'],
})
export class EditWorkoutComponent implements OnInit {
  editingExercise: boolean = false;
  exercises: ExercisePreview[] = [];
  workoutId: number = 0;

  trainingForm = this.formBuilder.group({
    title: ['', Validators.required],
    date: [new Date(), Validators.required],
    exercisesWorkout: this.formBuilder.array([]),
  });

  constructor(
    private formBuilder: FormBuilder,
    private exerciseService: ExercisesService,
    private toastrService: ToastrService,
    private dateSharingService: DateSharingService,
    private workoutsService: WorkoutsService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  get exercisesWorkout() {
    return this.trainingForm.get('exercisesWorkout') as FormArray;
  }

  get exerciseControls() {
    return (this.trainingForm.get('exercisesWorkout') as FormArray).controls;
  }

  // ... (Remaining methods remain unchanged)

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam !== null) {
      this.workoutId = +idParam;
    } else {
      this.toastrService.error('Błąd podczas pobierania id!');
    }
    this.fetchWorkoutDetails();
    this.fetchExercises();
    this.trainingForm.valueChanges.subscribe((x) => console.log(x));
    console.log(this.editingExercise);
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
  
  

  private fetchWorkoutDetails() {
    this.workoutsService.getWorkoutById(this.workoutId).subscribe(
      (workout: WorkoutPreviewWithDetails) => {
        console.log(workout);
        this.trainingForm.patchValue({
          title: workout.title,
          date: new Date(workout.date),
        });

        const exercisesWorkoutArray = this.trainingForm.get('exercisesWorkout') as FormArray;
        workout.exercisesWorkout.forEach((exercise) => {
          exercisesWorkoutArray.push(
            this.formBuilder.group({
              exerciseId: [exercise.exerciseId, Validators.required],
              exerciseSets: this.formBuilder.array(
                exercise.exerciseSets.map((set) =>
                  this.formBuilder.group({
                    repetitions: [set.repetitions, Validators.required],
                    weight: [set.weight, Validators.required],
                  })
                )
              ),
            })
          );
        });
      },
      (error) => {
        console.error('Error fetching workout details:', error);
      }
    );
  }
  submit(){};

  // ... (Remaining methods remain unchanged)
}
