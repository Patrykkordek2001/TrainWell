import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {
  title = 'TrainWellApp';
  showHeader = true;

  ngOnInit(): void {
    this.checkToken();
  }

  constructor(private authService: AuthService) {}

  private checkToken(): void {
    var token = localStorage.getItem('tokenJWT');
    var isLoggedIn = token !== null;
    this.authService.updateLoggedIn(isLoggedIn);
  }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

  logout(): void {
    this.authService.updateLoggedIn(false);
    localStorage.removeItem('tokenJWT');
  }
}