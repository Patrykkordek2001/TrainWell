import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealPreview } from 'src/app/Models/diet/MealPreview';

@Injectable({
  providedIn: 'root'
})
export class MealService {
  constructor(private httpClient: HttpClient) { }


  getAllMeals(): Observable<MealPreview[]> {
    return this.httpClient.get<MealPreview[]>('https://localhost:7004/api/Meal/GetAllMeals');
  }
}
