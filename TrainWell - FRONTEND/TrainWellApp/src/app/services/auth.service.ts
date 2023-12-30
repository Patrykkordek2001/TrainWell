import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { RegistrationDto } from '../Models/RegistrationDto';
import { LoginDto } from '../Models/LoginDto';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  isLoggedIn: boolean = false;
  showHeader: boolean = false;
  token: string = '';

  constructor(private httpClient: HttpClient) {}

  login(loginData: LoginDto): Observable<any> {
    return this.httpClient.post<number>(
      'https://localhost:7004/api/Auth/Login',
      loginData
    );
  }
  updateLoggedIn(value: boolean): void {
    this.isLoggedIn = value;
    if (value == true) {
      setTimeout(() => {
        this.setTimeToRefreshToken();
      }, 5 * 60 * 1000);
    }
  }
  setToken(token: string): void {
    this.token = token;
  }
  updateLocalStorage(token: string): void {
    localStorage.setItem('tokenJWT', token);
  }
  setTimeToRefreshToken() {
    timer(0, 5 * 60 * 1000)
      .pipe(switchMap(() => this.refreshToken()))
      .subscribe(
        (response) => {
          const newToken = response.token;
          this.setToken(newToken);
          this.updateLocalStorage(newToken);
        },
        (error) => {
          console.error('Error refreshing token:', error);
        }
      );
  }
  refreshToken(): Observable<any> {
    return this.httpClient.post<any>(
      'https://localhost:7004/api/Auth/RefreshToken',
      {}
    );
  }

  register(registerData: RegistrationDto): Observable<any> {
    return this.httpClient.post<number>(
      'https://localhost:7004/api/Auth/Register',
      registerData
    );
  }
}
