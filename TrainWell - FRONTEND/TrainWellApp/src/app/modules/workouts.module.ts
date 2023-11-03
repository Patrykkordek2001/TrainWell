import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutsComponent } from '../components/workouts/workouts.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FullCalendarModule } from '@fullcalendar/angular';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [WorkoutsComponent],
  imports: [CommonModule, ReactiveFormsModule,ToastrModule.forRoot(),BrowserAnimationsModule,FullCalendarModule,MatDialogModule],
  exports: [WorkoutsComponent],
})
export class WorkoutsModule { }
