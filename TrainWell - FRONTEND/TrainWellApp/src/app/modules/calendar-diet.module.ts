import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FullCalendarModule } from '@fullcalendar/angular';
import { MatDialogModule } from '@angular/material/dialog';
import { CalendarDietComponent } from '../components/calendars/calendar-diet/calendar-diet.component';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [CalendarDietComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    FullCalendarModule,
    MatDialogModule,
    MatButtonModule
  ],
  exports: [CalendarDietComponent],
})
export class CalendarDietModule { }
