import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegistrationDto } from '../Models/RegistrationDto';
import { LoginDto } from '../Models/LoginDto';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn: boolean = false;
  showHeader : boolean = false;


  constructor(private httpClient: HttpClient) { }

  updateLoggedIn(value: boolean): void {
    this.isLoggedIn = value;
  }

  updateShowHeader(value: boolean): void {
    this.showHeader = value;
  }

  register(registerData: RegistrationDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Auth/Register',registerData);
  }

  login(loginData: LoginDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Auth/Login',loginData);
  }
}

