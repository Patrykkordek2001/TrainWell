import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes, RoutesRecognized } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { WorkoutsAndMeasurementsComponent } from './components/workouts/workouts-and-measurements.component';
import { AddMeasurementComponent } from './components/measurements/add-measurement/add-measurement.component';

const routes: Routes = [
  { path: 'autoryzjacja', component: AuthComponent },
  { path: 'treningi', component: WorkoutsAndMeasurementsComponent },
  { path: 'dieta', component: WorkoutsAndMeasurementsComponent },
  { path: 'pomiar', component: AddMeasurementComponent },
  
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
