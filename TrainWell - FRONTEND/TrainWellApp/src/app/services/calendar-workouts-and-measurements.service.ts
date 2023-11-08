import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkoutPreview } from '../Models/workouts/WorkoutPreview';

@Injectable({
  providedIn: 'root'
})
export class CalendarWorkoutsAndMeasurementsService {
  
  constructor(private httpClient: HttpClient) { }


  getAllWorkouts(): Observable<WorkoutPreview[]> {
    return this.httpClient.get<WorkoutPreview[]>('https://localhost:7004/api/Workout/GetAllWorkouts');
  }
}
