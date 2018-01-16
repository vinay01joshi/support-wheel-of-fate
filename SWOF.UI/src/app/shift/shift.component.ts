import { Component, OnInit } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { subDays, addDays } from 'date-fns';

import { ShiftService } from '../services/shift.service';
import { debug } from 'util';
import { colors } from '../utils/colors';

@Component({
  selector: 'shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {

  shifts;
  constructor(private shiftService: ShiftService) { }

  ngOnInit() {
    this.shiftService.schedule().subscribe(shifts => {      
      this.shifts = shifts
    });  
      
  }

  view: string = 'month';
  viewDate: Date = new Date();
  events: CalendarEvent[] = [
    {
      start: new Date('2018-01-01'),
      end: new Date('2018-01-05'),
      title: 'One day excluded event',
      color: colors.red
    },
    {
      start: new Date('2016-01-01'),
      end: new Date('2016-01-09'),
      title: 'Multiple weeks event',
      color: colors.yellow
    }
  ];

  // exclude weekends
  excludeDays: number[] = [0, 6];
  skipWeekends(direction: 'back' | 'forward'): void {
    if (this.view === 'day') {
      if (direction === 'back') {
        while (this.excludeDays.indexOf(this.viewDate.getDay()) > -1) {
          this.viewDate = subDays(this.viewDate, 1);
        }
      } else if (direction === 'forward') {
        while (this.excludeDays.indexOf(this.viewDate.getDay()) > -1) {
          this.viewDate = addDays(this.viewDate, 1);
        }
      }
    }
  }
}
