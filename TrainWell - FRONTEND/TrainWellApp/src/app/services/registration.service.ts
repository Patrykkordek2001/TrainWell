import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegistrationDto } from '../Models/RegistrationDto';


@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private httpClient: HttpClient) { }

  register(registerData: RegistrationDto): Observable<any> {
    return this.httpClient.post<number>(
      'https://localhost:7004/api/Auth/Register',
      registerData
    );
  }
}

