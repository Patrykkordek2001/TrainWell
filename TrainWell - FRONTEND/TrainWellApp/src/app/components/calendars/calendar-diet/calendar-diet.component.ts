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
import { MealEnum } from 'src/app/Models/diet/MealEnum';


@Component({
  selector: 'app-calendar-diet',
  templateUrl: './calendar-diet.component.html',
  styleUrls: ['./calendar-diet.component.css']
})
export class CalendarDietComponent implements OnInit {
  calendarOptions?: CalendarOptions;
  @ViewChild('fullcalendar') fullcalendar?: FullCalendarComponent;
  meals: EventInput[] = [];
  constructor(
    private mealsService: MealService,
    private dialog: MatDialog,
    private mealService: MeasurementsService,
    private router: Router,
    private toastrService: ToastrService,
    private dateSharingService: DateSharingService
  ) {}
  ngOnInit() {
    this.getAllMeals();

    
  }

  

  getAllMeals() {
    this.mealsService.getAllMeals().subscribe((response) => {    
      this.meals = response.map((meal) => ({
        id: meal.id.toString(),
        title: this.getMealNameLabel(meal.mealName),
        start: meal.date,
        allDay: true,
        color: 'blue',
        textColor: 'white',
      }));
      if (this.fullcalendar) {
        this.fullcalendar.getApi().addEventSource(this.meals);
      }

    });

    this.calendarOptions = {
      initialView: 'dayGridWeek',
      plugins: [dayGridPlugin, interactionPlugin, bootstrap5Plugin],
      editable: true,
      timeZone: 'local',
      locale: 'pl',
      eventBackgroundColor: '#ff0000',
      dateClick: this.handleDateClick.bind(this),
      eventClick: this.eventClick.bind(this),
    };
  }

  handleDateClick(date: DateClickArg) {
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

  getMealNameLabel(meal: MealEnum): string {
    switch (meal) {
      case MealEnum.Default:
        return 'Brak';
      case MealEnum.Breakfast:
        return 'Śniadanie';
      case MealEnum.SecondBreakfast:
        return 'Drugie śniadanie';
      case MealEnum.Lunch:
        return 'Obiad';
      case MealEnum.Snack:
        return 'Przekąska';
      case MealEnum.Dinner:
        return 'Kolacja';
      default:
        return 'Brak';
    }
  }
}
