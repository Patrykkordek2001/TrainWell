import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivityEnum } from 'src/app/Models/User/ActivityEnum';
import { GenderEnum } from 'src/app/Models/User/GenderEnum';
import { GoalEnum } from 'src/app/Models/User/GoalEnum';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
  styleUrls: ['./user-panel.component.css'],
})
export class UserPanelComponent implements OnInit {
  addingPhoneNumber: boolean = false;
  userId!: number;
  email!: string;
  username!: string;

  caloriesPerDay:number = 0;
  fatPerDay:number = 0;
  carbohydratesPerDay:number = 0;
  proteinsPerDay:number = 0;
  // proteins!:number;
  // fat!:number;
  // carbo!:number;
  // kcal!:number;

  genders = [GenderEnum.Default, GenderEnum.Male, GenderEnum.Female];
  activities = [
    ActivityEnum.Resting,
    ActivityEnum.Low,
    ActivityEnum.Average,
    ActivityEnum.ActiveLifestyle,
    ActivityEnum.VeryActiveLifestyle,
    ActivityEnum.ProfessionallyPracticingSports,
  ];
  goals = [GoalEnum.Default, GoalEnum.Maintenance, GoalEnum.Reduction,GoalEnum.Gaining];

  userInfoForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private toastrService: ToastrService
  ) {}
  ngOnInit(): void {
    this.fetchUser();
    this.userInfoForm = this.formBuilder.group({
      weight: ['', [Validators.required]],
      growth: ['', [Validators.required]],
      age: ['', [Validators.required]],
      activity: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      goal: ['', [Validators.required]],
      // caloriesPerDay: ['', [Validators.required]],
      // fatPerDay: ['', [Validators.required]],
      // carbohydratesPerDay: ['', [Validators.required]],
      // proteinsPerDay: ['', [Validators.required]],
      
    });
  }

  // get caloriesPerDay() {
  //   return this.userInfoForm.get('caloriesPerDay')?.value;
  // }
  // get fatPerDay() {
  //   return this.userInfoForm.get('fatPerDay')?.value;
  // }
  // get carbohydratesPerDay() {
  //   return this.userInfoForm.get('carbohydratesPerDay')?.value;
  // }
  // get proteinsPerDay() {
  //   return this.userInfoForm.get('proteinsPerDay')?.value;
  // }


  fetchUser() {
    this.userService.getCurrentUser().subscribe((user) => {
      console.log(user);
      this.userId = user.id;
      this.username = user.username;
      this.email = user.email;
      if (user.userInfo === null) {
        user.userInfo = {
          id: 0,
          weight: 0,
          growth: 0,
          age: 0,
          activity: 0,
          gender: 0,
          goal: 0,
          caloriesPerDay: 0,
          fatPerDay: 0,
          carbohydratesPerDay: 0,
          proteinsPerDay: 0,
          userId: user.id,
        };
      }

      this.userInfoForm.patchValue({
        weight: user.userInfo.weight,
        growth: user.userInfo.growth,
        age: user.userInfo.age,
        activity: user.userInfo.activity,
        gender: user.userInfo.gender,
        goal: user.userInfo.goal,
        userId: user.id,
      });

      this.caloriesPerDay = user.userInfo.caloriesPerDay;
      this.fatPerDay = user.userInfo.fatPerDay;
      this.carbohydratesPerDay = user.userInfo.carbohydratesPerDay;
      this.proteinsPerDay = user.userInfo.proteinsPerDay;
    });
  }

  getGenderLabel(gender: GenderEnum): string {
    switch (gender) {
      case GenderEnum.Default:
        return 'Brak';
      case GenderEnum.Male:
        return 'Mężczyzna';
      case GenderEnum.Female:
        return 'Kobieta';
      default:
        return 'Brak';
    }
  }

  getGoalLabel(goal: GoalEnum): string {
    switch (goal) {
      case GoalEnum.Default:
        return 'Brak';
      case GoalEnum.Maintenance:
        return 'Utrzymanie wagi';
      case GoalEnum.Reduction:
        return 'Redukcja';
      case GoalEnum.Gaining:
        return 'Przytycie';
      default:
        return 'Brak';
    }
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

  calculateCalories() {
    console.log(this.userInfoForm.value);
    if (this.userInfoForm.valid) {
      const userData = this.userInfoForm.value;
      userData.userId = this.userId;
      this.userService.calculateCalories(userData).subscribe({
        next: (calculatedMacronutrients) => {
          this.caloriesPerDay = calculatedMacronutrients.caloriesPerDay;
          this.fatPerDay = calculatedMacronutrients.fatPerDay;
          this.carbohydratesPerDay = calculatedMacronutrients.carbohydratesPerDay;
          this.proteinsPerDay = calculatedMacronutrients.proteinsPerDay;
        },
        error: (error) => {
          this.toastrService.error(
            'Wystąpił błąd podczas dodawnia informacji.'
          );
        },
      });
    } else {
      this.toastrService.error('Wystąpił błąd podczas dodawnia informacji.');
    }
  }
}
