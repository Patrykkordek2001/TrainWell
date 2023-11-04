import { Component, Inject, OnInit, ViewChild, forwardRef } from '@angular/core';
import { Router } from '@angular/router';
import { FullCalendarComponent } from '@fullcalendar/angular';
import { Calendar, CalendarOptions, EventInput } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin, { DateClickArg } from '@fullcalendar/interaction';
import bootstrap5Plugin from '@fullcalendar/bootstrap5';
import { WorkoutPreview } from 'src/app/Models/workouts/WorkoutPreview';
import { WorkoutsService } from 'src/app/services/workouts.service';
import { DateClickComponentComponent } from '../date-click-component/date-click-component.component';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-menu',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css'],
})


export class WorkoutsComponent implements OnInit {
  calendarOptions?: CalendarOptions;
  @ViewChild('fullcalendar') fullcalendar?: FullCalendarComponent;
  trainingMode: boolean = false;
  workouts: EventInput[] = [];
  events = {
    events: [
      {
        title: 'Event1',
        start: '2023-11-02'
      },
      {
        title: 'Event2',
        start: '2011-05-05'
      }
      // etc...
    ],
    color: 'yellow',   // an option!
    textColor: 'black' // an option!
  }
constructor(private workoutsService:WorkoutsService,private dialog: MatDialog) {

} 
  ngOnInit() {
    this.getAllWorkouts();
    console.log(this.workouts);
    console.log(this.events);

    this.calendarOptions = {
      plugins: [dayGridPlugin, interactionPlugin, bootstrap5Plugin],
      editable: true,
      timeZone: "local",
      locale:"pl",
      events:this.workouts  ,
      eventBackgroundColor: "#ff0000",
      dateClick: this.handleDateClick.bind(this),
    };


  }



  getAllWorkouts() {
    this.workoutsService.getAllWorkouts().subscribe(response => {
      this.workouts = response.map(workout => ({
        title: workout.title,
        start: new Date(workout.date).toISOString().split('T')[0], 
        color: 'black',
        textColor: 'white'
      }));
      console.log(this.workouts);
      if (this.fullcalendar) {
        this.fullcalendar.getApi().addEventSource(this.workouts);   
      }
    });
  }

  handleDateClick() {
    this.dialog.open(DateClickComponentComponent, {
      width: '30%',
      height: '30%',
      position: {
        top: '20%',
        bottom: '',
        left: '35%',
        right: ''
      },
      data: { exampleData: 'Przykładowe dane' } // Przekaż dane do dialogu
    });
  }

  eventClick(event: EventInput) {
    // const dialogRef = this.dialog.open(EventDetailsComponent, {
    //   width: '400px', // Dostosuj rozmiar dialogu do Twoich potrzeb
    //   data: event // Przekaż dane wydarzenia do komponentu dialogowego
    // });
  

  }
  
}
