import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes, RoutesRecognized } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { CalendarWorkoutsAndMeasurementsComponent } from './components/calendars/calendar-workouts-and-measurements/calendar-workouts-and-measurements.component';
import { AddMeasurementComponent } from './components/measurements/add-measurement/add-measurement.component';
import { EditMeasurementComponent } from './components/measurements/edit-measurement/edit-measurement.component';
import { AddWorkoutComponent } from './components/workouts/add-workout/add-workout.component';

const routes: Routes = [
  { path: 'autoryzjacja', component: AuthComponent },
  { path: 'kalendarz-treningi-pomiary', component: CalendarWorkoutsAndMeasurementsComponent },
  { path: 'dieta', component: CalendarWorkoutsAndMeasurementsComponent },
  { path: 'pomiar', component: AddMeasurementComponent },
  { path: 'edytuj-pomiar/:id', component: EditMeasurementComponent},
  { path: 'dodaj-trening', component: AddWorkoutComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(private router: Router) {
    this.router.events.subscribe((event) => {
      if (event instanceof RoutesRecognized && event.url === '/') {
        this.router.navigate(['/autoryzjacja']);
      }
    });
  }
 }
