import { Component, OnInit } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';

@Component({
  selector: 'shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  view: string = 'month';

  viewDate: Date = new Date();

  events: CalendarEvent[] = [];

  clickedDate: Date;

}
