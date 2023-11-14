import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppComponent } from 'src/app/app.component';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  registrationForm!: FormGroup;
  loginForm!: FormGroup;
  loginMode: boolean = false;
  showHeader = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastrService: ToastrService,
    private appComponent: AppComponent,
    private router: Router
  ) {
    this.appComponent.showHeader = false;
  }

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required]],
    });
  }

  register() {
    const register = this.registrationForm.value;
    console.log(register);
    if (this.registrationForm.valid) {
      const userData = this.registrationForm.value;
      if (userData.password.value == userData.confirmPassword.value) {
        this.authService
          .register(userData)
          .subscribe({
            next: () => {
              this.changeMode();
              this.toastrService.success('Konto zostało utworzone');
            },
            error: (error) => {
              this.toastrService.error(error.error);
            },
          });
      }
    }else{
      this.toastrService.error('Wypełnij poprawnie wszystkie pola!');
    }
  }

  login() {
    if (this.loginForm.valid) {
      const userData = this.loginForm.value;
      this.authService
        .login(userData)
        .subscribe(
          (response) => {
            localStorage.setItem('tokenJWT', response.token);
            this.authService.updateLoggedIn(true);
            console.log(response.user.username);
            this.toastrService.success("Witaj " + response.user.username);

            this.router.navigate(['/kalendarz-treningi-pomiary']);
          },
          (error) => {
            console.error("Login failed:", error);
            this.toastrService.error("Niepoprawna nazwa użytkownika lub hasło");
          }
        );
    }
  }
  
  changeMode() {
    this.loginMode = !this.loginMode;
    if(this.loginMode){
      this.loginForm = this.formBuilder.group({
        username: ['', [Validators.required]],
        password: ['', [Validators.required, Validators.minLength(6)]],
      });
    }
    else if(!this.loginMode){
      this.registrationForm = this.formBuilder.group({
        username: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
        phoneNumber: ['', [Validators.required]],
      });     
    }
  }
}
