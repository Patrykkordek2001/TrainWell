import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-date-click-component',
  templateUrl: './date-click-component.component.html',
  styleUrls: ['./date-click-component.component.css']
})
export class DateClickComponentComponent {
/**
 *
 */
constructor(private router: Router,private dialog: MatDialog) {}

goToMeasurement(){
  this.router.navigate(['/pomiar']);
  this.dialog.closeAll();
}

goToWorkout(){
  this.router.navigate(['/dodaj-trening']);
  this.dialog.closeAll();
}


}
