import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './modules/auth.module';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { CalendarWorkoutsAndMeasurementsModule } from './modules/calendar-workouts-and-measurements.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DateClickComponentComponent } from './components/date-click-component/date-click-component.component';
import { MeasurementsModule } from './modules/measurements.module';
import { WorkoutsModule } from './modules/workouts.module';
import { MatIconModule } from '@angular/material/icon';
import { UserPanelModule } from './modules/user-panel.module';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MealsComponent } from './components/diet/meals/meals.component';
import { CalendarDietModule } from './modules/calendar-diet.module';
import { MatButtonModule } from '@angular/material/button';
import { DietModule } from './modules/diet.module';


@NgModule({
  declarations: [
    AppComponent,
    DateClickComponentComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    CalendarWorkoutsAndMeasurementsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MeasurementsModule,
    WorkoutsModule,
    MatIconModule,
    UserPanelModule,
    MatToolbarModule,
    CalendarDietModule,
    MatButtonModule,
    DietModule
    
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
