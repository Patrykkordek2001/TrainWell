import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  trainingForm: FormGroup;
  addingExercise: boolean = false;
  addingExerciseToList: boolean = false;
  exercises: ExercisePreview[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private trainingService: WorkoutsService,
    private exerciseService: ExercisesService,
    private toastrService: ToastrService
  ) {
    this.trainingForm = this.formBuilder.group({
      title: ['', Validators.required],
      date: ['', Validators.required],
      nameOfExercise:[''],
      exercises: this.formBuilder.array([]),
    });
  }

  ngOnInit(): void {
    this.fetchExercises();
    console.log(this.addingExercise);
  }
  submit(){}
  onSubmit() {
    // if (this.trainingForm.valid) {
    //   const trainingData = this.trainingForm.value;
    //   this.trainingService.addTraining(trainingData).subscribe(
    //     response => {
    //       console.log('Trening został dodany.', response);
    //       this.trainingForm.reset();
    //     },
    //     (error) => {
    //       console.error('Błąd podczas dodawania treningu.', error);
    //     }
    //   );
    // }
  }

  // get exerciseForms() {
  //   return this.trainingForm.get('exercises') as FormArray;
  // }

  addExercise() {
    this.addingExercise = true;
  }
  cancelAddingExercise(){
    this.addingExercise = false;

  }

  addExerciseToList(){
    this.addingExerciseToList = true;

  }
  get nameOfExercise(){
    return this.trainingForm.get("nameOfExercise")?.value;
  }

  addExerciseToListSubmit() {
    let exercise: ExerciseDto = {
      name: this.nameOfExercise as string,
    }
    this.exerciseService.addExercise(exercise).subscribe(
      (response) => {
        this.exercises.push(response);
        this.toastrService.success("Ćwiczenie zostało dodane do listy");
        this.cancelAddingExerciseToList();
      },
      (error) => {
        console.error("Błąd podczas dodawania ćwiczenia:", error);
        this.toastrService.error("Wystąpił błąd podczas dodawania ćwiczenia.");
      }
    );
  }
  
  cancelAddingExerciseToList(){
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
        this.toastrService.warning(error.error.text)

      }
    );
  }
}
