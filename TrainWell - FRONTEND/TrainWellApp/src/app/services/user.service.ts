import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserPreview } from '../Models/User/UserPreview';
import { UserInfoDto } from '../Models/User/UserInfoDto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getCurrentUser(): Observable<UserPreview> {
    return this.httpClient.get<UserPreview>(`https://localhost:7004/api/User/GetCurrentUser`);
  }
  calculateCalories(userInfoData: UserInfoDto): Observable<any> {
    return this.httpClient.post<UserInfoDto>('https://localhost:7004/api/User/UpdateOrAddUserInfo',userInfoData);
  }
}
