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
import { ExercisesService } from 'src/app/services/exercises.service';
import { WorkoutsService } from 'src/app/services/workouts.service';

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
        date: ['', Validators.required],
        nameOfExercise: ['', Validators.required],
        excersises: this.formBuilder.array([
            this.formBuilder.group({
                name: ['', Validators.required],
                excersisesSet: this.formBuilder.array([
                    this.formBuilder.group({
                        numberOfRepetition: ['', Validators.required],
                        weight: ['', Validators.required]
                    })
                ])
            })
        ])
    });

    constructor(private formBuilder: FormBuilder, private exerciseService: ExercisesService, private toastrService: ToastrService) { }

    // ngOnInit(): void {
    //     this.trainingForm.valueChanges.subscribe(x => console.log(x));
    // }

    get excersises() {
        return this.trainingForm.get('excersises') as FormArray;
    }

    get exerciseControls() {
        return (this.trainingForm.get('excersises') as FormArray).controls;
    }

    getExerciseSets(exerciseIndex: number) {
        return (this.exerciseControls[exerciseIndex].get('excersisesSet') as FormArray).controls;
    }

    addSet(exerciseIndex: number): void {
        const exerciseSet = this.excersises.at(exerciseIndex).get('excersisesSet') as FormArray;
        exerciseSet.push(this.formBuilder.group({
            numberOfRepetition: ['', Validators.required],
            weight: ['', Validators.required]
        }));
    }

    removeSet(exerciseIndex: number, setIndex: number): void {
        const exerciseSet = this.excersises.at(exerciseIndex).get('excersisesSet') as FormArray;
        exerciseSet.removeAt(setIndex);
    }

    removeExercise(exerciseIndex: number): void {
        this.excersises.removeAt(exerciseIndex);
    }

    addExercise(): void {
        this.excersises.push(this.formBuilder.group({
            name: ['', Validators.required],
            excersisesSet: this.formBuilder.array([])
        }));
    }


    submit() {

    }

    onSubmit() {

    }

    ngOnInit(): void {
      this.fetchExercises();
      this.trainingForm.valueChanges.subscribe(x => console.log(x));
      console.log(this.addingExercise);
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
