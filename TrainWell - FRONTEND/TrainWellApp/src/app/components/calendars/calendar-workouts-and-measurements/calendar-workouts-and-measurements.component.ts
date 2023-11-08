import {
  Component,
  Inject,
  OnInit,
  ViewChild,
  forwardRef,
} from '@angular/core';
import { Router } from '@angular/router';
import { FullCalendarComponent } from '@fullcalendar/angular';
import { Calendar, CalendarOptions, EventClickArg, EventInput } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin, { DateClickArg } from '@fullcalendar/interaction';
import bootstrap5Plugin from '@fullcalendar/bootstrap5';
import { WorkoutPreview } from 'src/app/Models/workouts/WorkoutPreview';
import { CalendarWorkoutsAndMeasurementsService } from 'src/app/services/calendar-workouts-and-measurements.service';
import { DateClickComponentComponent } from '../../date-click-component/date-click-component.component';
import { MatDialog } from '@angular/material/dialog';
import { MeasurementsService } from 'src/app/services/measurements.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-menu',
  templateUrl: './calendar-workouts-and-measurements.component.html',
  styleUrls: ['./calendar-workouts-and-measurements.component.css'],
})
export class CalendarWorkoutsAndMeasurementsComponent implements OnInit {
  calendarOptions?: CalendarOptions;
  @ViewChild('fullcalendar') fullcalendar?: FullCalendarComponent;
  trainingMode: boolean = false;
  workouts: EventInput[] = [];
  measurements: EventInput[] = [];
  events: EventInput[] = [];
  constructor(
    private workoutsService: CalendarWorkoutsAndMeasurementsService,
    private dialog: MatDialog,
    private measurementsService: MeasurementsService,
    private router: Router,
    private toastrService: ToastrService
  ) {}
  ngOnInit() {
    this.getAllWorkouts();
    this.getAllMeasurements();

    this.calendarOptions = {
      plugins: [dayGridPlugin, interactionPlugin, bootstrap5Plugin],
      editable: true,
      timeZone: 'local',
      locale: 'pl',
      events: this.events,
      eventBackgroundColor: '#ff0000',
      dateClick: this.handleDateClick.bind(this),
      eventClick: this.eventClick.bind(this),
    };
  }

  getAllWorkouts() {
    this.workoutsService.getAllWorkouts().subscribe((response) => {
      this.workouts = response.map((workout) => ({
        id: workout.id.toString(),
        groupId: 'trening',
        title: workout.title,
        start: workout.date,
        allDay: true,
        color: 'black',
        textColor: 'white',
      }));
      console.log(this.workouts);
      if (this.fullcalendar) {
        this.fullcalendar.getApi().addEventSource(this.workouts);
      }
    });
  }

  getAllMeasurements() {
    this.measurementsService.getAllMeasurements().subscribe((response) => {
      console.log(this.measurements);
      console.log(response);
      this.measurements = response.map((measurement) => ({
        id: measurement.id.toString(),
        groupId: 'pomiar',
        title: 'Pomiar ciała',
        allDay: true,
        start: measurement.date,
        color: 'blue',
        textColor: 'white',
      }));
      console.log(this.measurements);
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
        right: '',
      },
      data: { date: date },
    });
  }

  eventClick(event: EventClickArg) {
    console.log(event.event.groupId);
    
    if (event.event.groupId == 'pomiar') {
      this.router.navigate(['/edytuj-pomiar/' + event.event.id]);
    } else if (event.event.groupId == 'trening') {
      this.router.navigate(['/edytuj-trening/' + event.event.id]);
    } else {
      this.toastrService.error("Wystąpił błąd podczas wybierania zdarzenia!")
    }
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }
}
