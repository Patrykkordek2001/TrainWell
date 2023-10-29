import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes, RoutesRecognized } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { MenuComponent } from './components/menu/menu.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'menu', component: MenuComponent }
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
