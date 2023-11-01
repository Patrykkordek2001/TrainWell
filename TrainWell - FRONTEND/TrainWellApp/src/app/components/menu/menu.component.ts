import { Component, OnInit, ViewChild, forwardRef } from '@angular/core';
import { Router } from '@angular/router';
import { FullCalendarComponent } from '@fullcalendar/angular';
import { Calendar, CalendarOptions } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin, { DateClickArg } from '@fullcalendar/interaction'
// import 'bootstrap/dist/css/bootstrap.css';
// import 'bootstrap-icons/font/bootstrap-icons.css'; 
// import bootstrap5Plugin from '@fullcalendar/bootstrap5';



@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{


  calendarOptions?: CalendarOptions;
  eventsModel: any;
  @ViewChild('fullcalendar') fullcalendar?: FullCalendarComponent;

  ngOnInit() {
    // need for load calendar bundle first
    forwardRef(() => Calendar);

    this.calendarOptions = {
      plugins: [dayGridPlugin, interactionPlugin],
      editable: true,
      themeSystem: 'bootstrap5',

      // customButtons: {
      //   myCustomButton: {
      //     text: 'custom!',
      //     click: function () {
      //       alert('clicked the custom button!');
      //     }
      //   }
      // },
      // headerToolbar: {
      //   left: 'prev,next today myCustomButton',
      //   center: 'title',
      //   right: 'dayGridMonth'
      // },
      dateClick: this.handleDateClick.bind(this),


    };
  }

  handleDateClick(arg: DateClickArg) {
    console.log(arg);
  }

}
