import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkoutsService {

  constructor(private httpClient: HttpClient) { }


  // addMeasurement():  {
  //   //return this.httpClient.post<number>('https://localhost:7004/api/Measurement/AddMeasurement');
  // }

}
