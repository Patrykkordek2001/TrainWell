import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { RegistrationDto } from '../Models/RegistrationDto';
import { LoginDto } from '../Models/LoginDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn: boolean = false;
  showHeader: boolean = false;
  token: string = '';  // Przechowuj token JWT tutaj

  constructor(private httpClient: HttpClient) {}

  setTimeToRefreshToken(){
    console.log("set");
    timer(0, 25 * 60 * 1000).pipe(
      switchMap(() => this.refreshToken())
    ).subscribe(
      (response) => {
        console.log(response)
        const newToken = response.token;
        this.setToken(newToken);
        console.log('Token refreshed successfully.');
        this.updateLocalStorage(newToken);
      },
      (error) => {
        console.error('Error refreshing token:', error);
      }
    );
  }
  

  updateLoggedIn(value: boolean): void {
    this.isLoggedIn = value;
    if (value == true) {
      setTimeout(() => {
        this.setTimeToRefreshToken();
      },25 * 60 * 1000); 
    }
  }

  updateShowHeader(value: boolean): void {
    this.showHeader = value;
  }

  setToken(token: string): void {
    this.token = token;
  }

  updateLocalStorage(token: string): void {
    localStorage.setItem('tokenJWT', token);
  }

  refreshToken(): Observable<any> {
    return this.httpClient.post<any>('https://localhost:7004/api/Auth/RefreshToken', {});
  }

  register(registerData: RegistrationDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Auth/Register', registerData);
  }

  login(loginData: LoginDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Auth/Login', loginData);
  }
}
