import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddMeasurementComponent } from '../components/measurements/add-measurement/add-measurement.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DateAdapter, MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [AddMeasurementComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule
  ],
  exports: [AddMeasurementComponent],
//   providers: [{ provide: MAT_DATE_LOCALE, useValue: 'fr-FR' }
// ,{
//   provide:DateAdapter,
//   useClass:MomentDateAdapter,
//   deps: [MAT_DATE_LOCALE,MAT_MOMENT_DATE_ADAPTER_OPTIONS]
// },]

})
export class MeasurementsModule {}
