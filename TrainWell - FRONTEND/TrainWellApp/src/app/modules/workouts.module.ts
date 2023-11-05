import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutsAndMeasurementsComponent } from '../components/workouts/workouts-and-measurements.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FullCalendarModule } from '@fullcalendar/angular';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [WorkoutsAndMeasurementsComponent],
  imports: [CommonModule, ReactiveFormsModule,ToastrModule.forRoot(),BrowserAnimationsModule,FullCalendarModule,MatDialogModule],
  exports: [WorkoutsAndMeasurementsComponent],
})
export class WorkoutsModule { }
