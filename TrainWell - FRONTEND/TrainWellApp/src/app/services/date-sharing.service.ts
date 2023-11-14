import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateSharingService {
  private selectedDate!: Date;

  constructor() { }

  setSelectedDate(date: Date) {
    this.selectedDate = date;
    console.log(this.selectedDate);
  }

  getSelectedDate() {
    console.log(this.selectedDate);
    return this.selectedDate;
    
  }
}
