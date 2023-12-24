import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkoutDto } from '../../Models/workouts/WorkoutDto';
import { WorkoutPreview } from 'src/app/Models/workouts/WorkoutPreview';
import { WorkoutPreviewWithDetails } from 'src/app/Models/workouts/WorkoutPreviewWithDetails';

@Injectable({
  providedIn: 'root'
})
export class WorkoutsService {

  constructor(private httpClient: HttpClient) { }

  addWorkout(workoutData: WorkoutDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Workout/AddWorkout',workoutData);
  }


  updateWorkout(workoutData: WorkoutDto): Observable<any> {
    return this.httpClient.put('https://localhost:7004/api/Workout/UpdateWorkout',workoutData);
  }


  getWorkoutById(id: number): Observable<WorkoutPreviewWithDetails> {
    return this.httpClient.get<WorkoutPreviewWithDetails>(`https://localhost:7004/api/Workout/GetWorkoutByID/${id}`);
  }
}
