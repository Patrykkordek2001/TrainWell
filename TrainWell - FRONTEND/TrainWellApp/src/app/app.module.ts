import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './modules/auth.module';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { WorkoutsAndMeasurementsComponent } from './components/workouts/workouts-and-measurements.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { WorkoutsModule } from './modules/workouts.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DateClickComponentComponent } from './components/date-click-component/date-click-component.component';
import { AddMeasurementComponent } from './components/measurements/add-measurement/add-measurement.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MeasurementsModule } from './modules/measurements.module';
import { EditMeasurementComponent } from './components/measurements/edit-measurement/edit-measurement.component';

@NgModule({
  declarations: [
    AppComponent,
    DateClickComponentComponent,
    EditMeasurementComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    WorkoutsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MeasurementsModule
    
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
