import { EngineerService } from './../services/engineer.service';
import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { debug } from 'util';
import { subDays, addDays } from 'date-fns';

import { ShiftService } from '../services/shift.service';
import { colors } from '../utils/colors';
import { Subscription } from 'rxjs/Subscription';
import { CalendarMonthViewDay } from 'angular-calendar';
@Component({
  selector: 'shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {

  days=[];
  shift:any;
  engineers;
  view: string = 'month';
  viewDate: Date = new Date();
  events: CalendarEvent[]=[]; 
  excludeDays: number[] = [0, 6];
  weekDays = ["Monday","Tuesday","Wednesday","Thursday","Friday"];
  constructor(private shiftService: ShiftService
      ,private engineerService: EngineerService) { }

   ngOnInit() {
     this.shiftService.schedule().subscribe(res => {
       this.shift = res;       
     });

     this.engineerService.getAll().subscribe(res => this.engineers = res);
   }  

   beforeMonthViewRender({ body }: { body: CalendarMonthViewDay[] }):void{ 
     this.shiftService.schedule().subscribe(res => {
       this.shift = res;
       let count = 0;
       body.forEach(day => {          
         if(day.date >= new Date()) {          
          let currentShift = this.shift.days[count++];   
          day.badgeTotal = 2;
          let engineers = currentShift.shifts[0].engineer.name + " And " + currentShift.shifts[1].engineer.name;           
          day.events.push({
           start: new Date(day.date),
           end: new Date(day.date),
           title: engineers,
           color: colors.red
          });       
         }              
       })
     })      
   }
  // exclude weekends
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
