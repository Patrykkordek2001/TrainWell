import { NgModule } from '@angular/core';
import { AuthComponent } from 'src/app/components/auth/auth.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [AuthComponent],
  imports: [CommonModule, ReactiveFormsModule,ToastrModule.forRoot(),BrowserAnimationsModule],
  exports: [AuthComponent],
})
export class AuthModule {}
