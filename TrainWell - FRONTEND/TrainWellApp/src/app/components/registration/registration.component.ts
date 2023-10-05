import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationService } from 'src/app/services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  registrationForm: FormGroup;


  constructor(private formBuilder: FormBuilder, private registerService: RegistrationService) {
    this.registrationForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required]],


    });
  }

  onSubmit() {
    console.log(2);
    if (this.registrationForm.valid) {

      const userData = this.registrationForm.value;
      if(userData.password.value == userData.confirmPassword.value){
        this.registerService.register(userData).subscribe(
          res => console.log(res),
          error => console.error(error)
        );
        
      }
      console.log('Dane formularza zostały wysłane:', this.registrationForm.value);
    }
  }
  backToLoginPage(){}

}
