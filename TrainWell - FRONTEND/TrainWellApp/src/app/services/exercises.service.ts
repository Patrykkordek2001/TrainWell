import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExercisePreview } from '../Models/exercises/ExercisePreview';
import { ExerciseDto } from '../Models/exercises/ExerciseDto';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {

  constructor(private httpClient: HttpClient) { }

  getAllExercises(): Observable<ExercisePreview[]> {
    return this.httpClient.get<ExercisePreview[]>('https://localhost:7004/api/Exercise/GetAllExercises');
  }

  addExercise(exerciseData: ExerciseDto): Observable<any> {
    console.log(exerciseData);
    return this.httpClient.post<ExercisePreview[]>('https://localhost:7004/api/Exercise/AddExercise',exerciseData);
  }
}
