import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkoutDto } from '../Models/workouts/WorkoutDto';

@Injectable({
  providedIn: 'root'
})
export class WorkoutsService {

  constructor(private httpClient: HttpClient) { }

  addWorkout(workoutData: WorkoutDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Workout/AddWorkout',workoutData);
  }

}
