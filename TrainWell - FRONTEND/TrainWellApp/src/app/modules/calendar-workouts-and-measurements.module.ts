import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarWorkoutsAndMeasurementsComponent } from '../components/calendars/calendar-workouts-and-measurements/calendar-workouts-and-measurements.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FullCalendarModule } from '@fullcalendar/angular';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [CalendarWorkoutsAndMeasurementsComponent],
  imports: [CommonModule, ReactiveFormsModule,ToastrModule.forRoot(),BrowserAnimationsModule,FullCalendarModule,MatDialogModule],
  exports: [CalendarWorkoutsAndMeasurementsComponent],
})
export class CalendarWorkoutsAndMeasurementsModule { }
