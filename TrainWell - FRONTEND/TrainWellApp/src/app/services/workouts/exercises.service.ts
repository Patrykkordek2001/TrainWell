import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExercisePreview } from '../../Models/exercises/ExercisePreview';
import { ExerciseDto } from '../../Models/exercises/ExerciseDto';

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
    return this.httpClient.post('https://localhost:7004/api/Exercise/AddExercise',exerciseData);
  }

  // deleteExercise(exerciseId: number): Observable<any> {
  //   const url = `${this.apiUrl}/api/exercises/${exerciseId}`;

  //   return this.http.delete(url);
  // }

  deleteExercise(exerciseId: number): Observable<any> {
    return this.httpClient.delete(`https://localhost:7004/api/Exercise/DeleteExerciseById/${exerciseId}`);
  }
}
