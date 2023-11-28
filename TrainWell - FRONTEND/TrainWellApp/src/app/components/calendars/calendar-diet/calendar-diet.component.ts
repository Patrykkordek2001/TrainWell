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
import { CalendarWorkoutsAndMeasurementsService } from 'src/app/services/workouts/calendar-workouts-and-measurements.service';
import { DateClickComponentComponent } from '../../date-click-component/date-click-component.component';
import { MatDialog } from '@angular/material/dialog';
import { MeasurementsService } from 'src/app/services/workouts/measurements.service';
import { ToastrService } from 'ngx-toastr';
import { DateSharingService } from 'src/app/services/date-sharing.service';
import { MealService } from 'src/app/services/diet/meal.service';


@Component({
  selector: 'app-calendar-diet',
  templateUrl: './calendar-diet.component.html',
  styleUrls: ['./calendar-diet.component.css']
})
export class CalendarDietComponent implements OnInit {
  calendarOptions?: CalendarOptions;
  @ViewChild('fullcalendar') fullcalendar?: FullCalendarComponent;
  events: EventInput[] = [];
  constructor(
    private mealsService: MealService,
    private dialog: MatDialog,
    private mealService: MeasurementsService,
    private router: Router,
    private toastrService: ToastrService,
    private dateSharingService: DateSharingService
  ) {}
  ngOnInit() {
    this.getAllMeasurements();

    this.calendarOptions = {
      initialView: 'dayGridWeek',
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

  

  getAllMeasurements() {
    this.mealsService.getAllMeals().subscribe((response) => {
      console.log(response);
      this.events = response.map((meal) => ({
        id: meal.id.toString(),
        title: meal.mealName.toString(),
        allDay: true,
        start: meal.date,
        color: 'blue',
        textColor: 'white',
      }));
      console.log(this.events);
      // if (this.fullcalendar) {
      //   this.fullcalendar.getApi().addEventSource(this.measurements);
      // }
    });
  }

  handleDateClick(date: DateClickArg) {
    console.log(date.date);
    this.dateSharingService.setSelectedDate(date.date);
    this.dialog.open(DateClickComponentComponent, {
      width: '30%',
      height: '30%',
      position: {
        top: '20%',
        bottom: '',
        left: '35%',
        right: '',
      },
      data: { date: date, dietMode: true},
    });
  }

  eventClick(event: EventClickArg) {
    // console.log(event.event.groupId);
    
    // if (event.event.groupId == 'pomiar') {
    //   this.router.navigate(['/edytuj-pomiar/' + event.event.id]);
    // } else if (event.event.groupId == 'trening') {
    //   this.router.navigate(['/edytuj-trening/' + event.event.id]);
    // } else {
    //   this.toastrService.error("Wystąpił błąd podczas wybierania zdarzenia!")
    // }
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }
}
