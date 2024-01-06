import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogRef,
} from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-date-click-component',
  templateUrl: './date-click-component.component.html',
  styleUrls: ['./date-click-component.component.css'],
})
export class DateClickComponentComponent {
  /**
   *
   */
  constructor(
    private router: Router,
    private dialogRef: MatDialogRef<DateClickComponentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    console.log(data.workoutMode);  
  }

  goToMeasurement() {
    this.router.navigate(['/pomiar']);
    this.dialogRef.close();
  }

  goToWorkout() {
    this.router.navigate(['/dodaj-trening']);
    this.dialogRef.close();  }

  goToMeals() {
    this.router.navigate(['/dodaj-posiłki']);
    this.dialogRef.close(); 
   }
   cancel(){
    
   }
}
