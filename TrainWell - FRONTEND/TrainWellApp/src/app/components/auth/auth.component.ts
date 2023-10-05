import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  registrationForm!: FormGroup;
  loginForm!: FormGroup;
  registerMode: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
      this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  register() {
    if (this.registrationForm.valid) {
      console.log(1);
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

  login(){
    if (this.loginForm.valid) {
      const userData = this.loginForm.value;
        this.authService
          .login(userData)
          .subscribe((response) => {
            localStorage.setItem('tokenJWT', response.token);
            this.authService.updateLoggedIn(true);
            console.log(response.user.username);
            this.toastrService.success("Witaj "+ response.user.username);
          });
      
    }
  }
  changeMode() {
    this.registerMode = !this.registerMode;
    if(this.registerMode){
      this.registrationForm = this.formBuilder.group({
        username: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
        phoneNumber: ['', [Validators.required]],
      });
    }
    else if(!this.registerMode){
      this.loginForm = this.formBuilder.group({
        username: ['', [Validators.required]],
        password: ['', [Validators.required, Validators.minLength(6)]],
      });
    }
  }
}
