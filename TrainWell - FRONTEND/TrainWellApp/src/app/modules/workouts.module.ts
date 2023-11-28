import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { AddWorkoutComponent } from '../components/workouts/add-workout/add-workout.component';
import { EditWorkoutComponent } from '../components/workouts/edit-workout/edit-workout.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { AddWorkoutComponent } from '../components/workouts/add-workout/add-workout.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MY_DATE_FORMATS } from '../shared/date-format';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [AddWorkoutComponent,EditWorkoutComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatSelectModule,
    MatOptionModule,
    MatIconModule,

  ],
  exports: [AddWorkoutComponent,EditWorkoutComponent],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pl-PL' }, 
    MY_DATE_FORMATS],


})
export class WorkoutsModule { }
