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
import { MeasurementsService } from 'src/app/services/measurements.service';


@Component({
  selector: 'app-menu',
  templateUrl: './workouts-and-measurements.component.html',
  styleUrls: ['./workouts-and-measurements.component.css'],
})


export class WorkoutsAndMeasurementsComponent implements OnInit {
  calendarOptions?: CalendarOptions;
  @ViewChild('fullcalendar') fullcalendar?: FullCalendarComponent;
  trainingMode: boolean = false;
  workouts: EventInput[] = [];
  measurements: EventInput[] = [];
  events: EventInput[]=[];
constructor(private workoutsService:WorkoutsService,private dialog: MatDialog, private measurementsService: MeasurementsService) {

} 
  ngOnInit() {
    this.getAllWorkouts();
    this.getAllMeasurements()

    this.calendarOptions = {
      plugins: [dayGridPlugin, interactionPlugin, bootstrap5Plugin],
      editable: true,
      timeZone: "local",
      locale:"pl",
      events:this.events  ,
      eventBackgroundColor: "#ff0000",
      dateClick: this.handleDateClick.bind(this),
    };


  }



  getAllWorkouts() {
    console.log(1);
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

  getAllMeasurements() {
    console.log(1);
    this.measurementsService.getAllMeasurements().subscribe(response => {
      console.log(this.measurements);
      this.measurements = response.map(measurement => ({
        title: "Pomiar ciała",
        start: new Date(measurement.date).toISOString().split('T')[0], 
        color: 'blue',
        textColor: 'white'
      }));
      if (this.fullcalendar) {
        this.fullcalendar.getApi().addEventSource(this.measurements);   

      }
    });
  }

  handleDateClick(date: DateClickArg) {
    this.dialog.open(DateClickComponentComponent, {
      width: '30%',
      height: '30%',
      position: {
        top: '20%',
        bottom: '',
        left: '35%',
        right: ''
      },
      data: { date: date }
    });
  }

  eventClick(event: EventInput) {
    // const dialogRef = this.dialog.open(EventDetailsComponent, {
    //   width: '400px', // Dostosuj rozmiar dialogu do Twoich potrzeb
    //   data: event // Przekaż dane wydarzenia do komponentu dialogowego
    // });
  

  }
  
}
