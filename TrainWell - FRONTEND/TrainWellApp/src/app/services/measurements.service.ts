import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MeasurementDto } from '../Models/measurements/MeasurementDto';
import { MeasurementPreview } from '../Models/measurements/MeasurementsPreview';

@Injectable({
  providedIn: 'root'
})
export class MeasurementsService {

  constructor(private httpClient: HttpClient) { }

  addMeasurement(measurementData: MeasurementDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Measurement/AddMeasurement',measurementData);
  }
  getAllMeasurements(): Observable<MeasurementPreview[]> {
    return this.httpClient.get<MeasurementPreview[]>('https://localhost:7004/api/Measurement/GetAllMeasurements');
  }
}
