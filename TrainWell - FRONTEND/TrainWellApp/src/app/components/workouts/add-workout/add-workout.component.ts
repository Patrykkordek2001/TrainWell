import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkoutsService } from 'src/app/services/workouts.service';

@Component({
  selector: 'app-add-workout',
  templateUrl: './add-workout.component.html',
  styleUrls: ['./add-workout.component.css']
})
export class AddWorkoutComponent implements OnInit {
  trainingForm: FormGroup;
  addingExercise:boolean = false;

  constructor(private formBuilder: FormBuilder, private trainingService: WorkoutsService) {
    this.trainingForm = this.formBuilder.group({
      title: ['', Validators.required],
      date: ['', Validators.required],
      exercises: this.formBuilder.array([])
    });
  }

  ngOnInit(): void {}

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

  get exerciseForms() {
    return this.trainingForm.get('exercises') as FormArray;
  }

  addExercise() {
    this.addingExercise = true;
  }
  

  removeExercise(index: number) {
    this.exerciseForms.removeAt(index);
  }

  addExerciseSet(exercise: FormGroup) {
    const exerciseSets = exercise.get('exerciseSets') as FormArray;
    exerciseSets.push(this.formBuilder.group({
      repetitions: ['', Validators.required],
      weight: ['', Validators.required]
    }));
  }

  removeExerciseSet(exercise: FormGroup, index: number) {
    const exerciseSets = exercise.get('exerciseSets') as FormArray;
    exerciseSets.removeAt(index);
  }
}
