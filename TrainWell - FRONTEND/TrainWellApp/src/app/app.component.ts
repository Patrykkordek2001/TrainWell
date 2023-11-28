import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  
})


export class AppComponent implements OnInit {

  title = 'TrainWellApp';

  ngOnInit(): void {
    this.checkToken();
  }
  

  constructor(private authService: AuthService, private router:Router) {}

  private checkToken(): void {
    var token = localStorage.getItem('tokenJWT');
    var isLoggedIn = token !== null;
    this.authService.updateLoggedIn(isLoggedIn);
  }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

  isAuthPage(): boolean {
    return this.router.url.includes('/autoryzacja');
  }
  logout(): void {
    this.authService.updateLoggedIn(false);
    localStorage.removeItem('tokenJWT');
    this.router.navigate(['/autoryzacja']);
    
  }

  navigateTo(url :string){
    this.router.navigate([url]);

  }
}