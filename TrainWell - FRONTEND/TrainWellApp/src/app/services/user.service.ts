import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserPreview } from '../Models/User/UserPreview';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getCurrentUserInfo(): Observable<UserPreview> {
    return this.httpClient.get<UserPreview>(`https://localhost:7004/api/User/GetCurrentUser`);
  }
}
