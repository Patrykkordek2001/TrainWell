import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  registrationForm: FormGroup;


  constructor(private formBuilder: FormBuilder, private registerService: RegisterService) {
    this.registrationForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required]],


    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {

      const userData = this.registrationForm.value;
      if(userData.password.value == userData.confirmPassword.value){
          
      }
      console.log('Dane formularza zostały wysłane:', this.registrationForm.value);
    }
  }
  backToLoginPage(){}

}
