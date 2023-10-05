import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes, RoutesRecognized } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';

const routes: Routes = [
  { path: 'register', component: RegistrationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(private router: Router) {
    this.router.events.subscribe((event) => {
      if (event instanceof RoutesRecognized && event.url === '/') {
        this.router.navigate(['/register']);
      }
    });
  }
 }
