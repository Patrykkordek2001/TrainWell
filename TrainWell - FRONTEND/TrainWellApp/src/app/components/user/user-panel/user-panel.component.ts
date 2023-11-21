import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivityEnum } from 'src/app/Models/User/ActivityEnum';
import { GenderEnum } from 'src/app/Models/User/GenderEnum';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
  styleUrls: ['./user-panel.component.css'],
})
export class UserPanelComponent implements OnInit {
  addingPhoneNumber: boolean = false;

  genders = [GenderEnum.Male, GenderEnum.Female];
  activities = [
    ActivityEnum.Resting,
    ActivityEnum.Low,
    ActivityEnum.Average,
    ActivityEnum.ActiveLifestyle,
    ActivityEnum.VeryActiveLifestyle,
    ActivityEnum.ProfessionallyPracticingSports,
  ];

  userInfoForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {}
  ngOnInit(): void {
    this.fetchUser();
    this.userInfoForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required]],
      weight: ['', [Validators.required]],
      growth: ['', [Validators.required]],
      age: ['', [Validators.required]],
      activity: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      caloriesPerDay: ['', [Validators.required]],
      fatPerDay: ['', [Validators.required]],
      carbohydratesPerDay: ['', [Validators.required]],
      proteinsPerDay: ['', [Validators.required]],
    });
  }

  get username() {
    return this.userInfoForm.get('username')?.value;
  }
  get email() {
    return this.userInfoForm.get('email')?.value;
  }
  get phoneNumber() {
    return this.userInfoForm.get('phoneNumber')?.value;
  }
  get gender() {
    return this.userInfoForm.get('gender')?.value;
  }

  fetchUser() {
    this.userService.getCurrentUserInfo().subscribe((user) => {
      console.log(user);
      if (user.userInfo === null) {
        user.userInfo = {
          id: 0,
          weight: 0,
          growth: 0,
          age: 0,
          activity: 0,
          gender: 0,
          caloriesPerDay: 0,
          fatPerDay: 0,
          carbohydratesPerDay: 0,
          proteinsPerDay: 0,
        };
      }

      this.userInfoForm.patchValue({
        username: user.username,
        email: user.email,
        phoneNumber: user.phoneNumber,
        weight: user.userInfo.weight,
        growth: user.userInfo.growth,
        age: user.userInfo.age,
        activity: user.userInfo.activity,
        gender: user.userInfo.gender,
        caloriesPerDay: user.userInfo.caloriesPerDay,
        fatPerDay: user.userInfo.fatPerDay,
        carbohydratesPerDay: user.userInfo.carbohydratesPerDay,
        proteinsPerDay: user.userInfo.proteinsPerDay,
      });
    });
  }

  chandeAddPhoneBool() {
    this.addingPhoneNumber = !this.addingPhoneNumber;
  }
  addPhoneNumber() {}

  getGenderLabel(gender: GenderEnum): string {
    return gender === GenderEnum.Male ? 'Mężczyzna' : 'Kobieta';
  }
  getActivityLabel(activity: ActivityEnum): string {
    switch (activity) {
      case ActivityEnum.Resting:
        return 'Brak aktywności';
      case ActivityEnum.Low:
        return 'Niska aktywność';
      case ActivityEnum.Average:
        return 'Średnia aktywność';
      case ActivityEnum.ActiveLifestyle:
        return 'Aktywny tryb życia';
      case ActivityEnum.VeryActiveLifestyle:
        return 'Bardzo aktywny tryb życia';
      case ActivityEnum.ProfessionallyPracticingSports:
        return 'Profesjonalne uprawianie sportu';
      default:
        return 'Nieznana aktywność';
    }
  }
}
