import { Component, OnInit, ViewChild } from '@angular/core';
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
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-edit-workout',
  templateUrl: './edit-workout.component.html',
  styleUrls: ['./edit-workout.component.css'],
})
export class EditWorkoutComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  editingExercise: boolean = false;
  exercises: ExercisePreview[] = [];
  exercisesForTable: ExercisePreview[] = [];
  workoutId: number = 0;
  addingExerciseToList: boolean = false;
  addingExercise: boolean = true;
  dataSource = new MatTableDataSource<ExercisePreview>(this.exercisesForTable);

  trainingForm = this.formBuilder.group({
    id: [0, Validators.required],
    title: ['', Validators.required],
    date: [new Date(), Validators.required],
    exercisesWorkout: this.formBuilder.array([]),
  });

  addExerciseForm = this.formBuilder.group({
    name: ['', Validators.required],
  });


  displayedColumns: string[] = [
    'Lp',
    'Nazwa',
    'Usuń'
  ];
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


  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam !== null) {
      this.workoutId = +idParam;
    } else {
      this.toastrService.error('Błąd podczas pobierania id!');
    }
    this.fetchExercisesForTable()
    this.fetchExercises();
    this.fetchWorkoutDetails();
    
    
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  fetchExercises() {
    this.exerciseService.getAllExercises().subscribe(
      (exercisesFromDatabase) => {
        this.exercises = exercisesFromDatabase;
        console.log(this.exercises);
      },
      (error) => {
        this.toastrService.warning(error.error.text);
      }
    );
  }

  fetchExercisesForTable(){
    this.exerciseService.getAllExercises().subscribe((response) => {
      this.exercisesForTable = response.map((product, index) => ({
        ...product,
        position: index + 1,
      }));
      this.dataSource.data = this.exercisesForTable;
      console.log(this.exercisesForTable);
    });
  }

  addExerciseToList() {
    this.addingExerciseToList = true;
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

  addExerciseToListSubmit() {
    let exercise: ExerciseDto = {
      name: this.addExerciseForm.get('name')?.value as string,
    };

    this.exerciseService.addExercise(exercise).subscribe(
      (response) => {
        this.exercises.push(response);
        const newExercises = {
          ...response,
          position: this.exercisesForTable.length + 1,
        };
        console.log(newExercises);
        this.exercisesForTable.push(newExercises);
        console.log(this.exercisesForTable);
        this.addExerciseForm.reset();
        this.table.renderRows();
        this.toastrService.success('Ćwiczenie zostało dodane do listy');
      },
      (error) => {
        console.error('Błąd podczas dodawania ćwiczenia:', error);
        this.toastrService.error('Wystąpił błąd podczas dodawania ćwiczenia.');
      }
    );
  }

  removeExercise(exerciseIndex: number): void {
    this.exercisesWorkout.removeAt(exerciseIndex);
  }
  cancelAddingExerciseToList() {
    this.addingExerciseToList = false;
  }
  addExercise(): void {
    this.exercisesWorkout.push(
      this.formBuilder.group({
        exerciseId: ['', Validators.required],
        workoutId: this.workoutId,
        exerciseSets: this.formBuilder.array([]),
      })
    );
  }
  addExerciseBool() {
    this.addingExercise = true;
  }
  cancelAddingExercise() {
    this.addingExercise = false;
  }
  
  

  private fetchWorkoutDetails() {
    this.workoutsService.getWorkoutById(this.workoutId).subscribe(
      (workout: WorkoutPreviewWithDetails) => {
        console.log(workout);
        this.trainingForm.patchValue({
          id: workout.id,
          title: workout.title,
          date: new Date(workout.date),
        });

        const exercisesWorkoutArray = this.trainingForm.get('exercisesWorkout') as FormArray;
        workout.exercisesWorkout.forEach((exercise) => {
          exercisesWorkoutArray.push(
            this.formBuilder.group({
              id:exercise.id,
              exerciseId: [exercise.exerciseId, Validators.required],
              workoutId: [exercise.workoutId, Validators.required],
              exerciseSets: this.formBuilder.array(
                exercise.exerciseSets.map((set) =>
                  this.formBuilder.group({
                    id: set.id,
                    repetitions: [set.repetitions, Validators.required],
                    weight: [set.weight, Validators.required],
                    exerciseWorkoutId:[set.exerciseWorkoutId, Validators.required]
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
  submit(){
    if (this.trainingForm.valid) {
      const workoutData = this.trainingForm.value as unknown as WorkoutDto;
      console.log(workoutData);
      this.workoutsService.updateWorkout(workoutData).subscribe(
        response => {
          console.log('Success:', response);
          this.router.navigate(['/kalendarz-treningi-pomiary']);
          this.toastrService.success("Trening został zaaktualizowany.");
        },
        error => {
          console.error('Error:', error);
          this.toastrService.error("Wystąpił błąd podczas dodawnia pomairu.");
        }
      );
    }
  };

  removeExerciseFromTable(id: number): void {
    const indexToRemove = this.exercisesForTable.findIndex(exercise => exercise.id === id);

    if (id !== -1) {
      this.exerciseService.deleteExercise(id).subscribe(response => {
        this.exercisesForTable.splice(indexToRemove, 1);
        this.dataSource.data = this.exercisesForTable;
        this.table.renderRows();
        console.log(this.exercisesForTable);
        this.toastrService.success('Ćwiczenie zostało usunięte z tabeli');
      },
      (error) => {
        this.toastrService.error('Wystąpił błąd podczas usuwania ćwiczenia.');
      })
      
    }
  }

}
