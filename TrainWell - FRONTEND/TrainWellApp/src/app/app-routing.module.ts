import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes, RoutesRecognized } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { WorkoutsComponent } from './components/workouts/workouts.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'workouts', component: WorkoutsComponent },
  { path: 'diet', component: WorkoutsComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(private router: Router) {
    this.router.events.subscribe((event) => {
      if (event instanceof RoutesRecognized && event.url === '/') {
        this.router.navigate(['/auth']);
      }
    });
  }
 }
