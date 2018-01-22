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
  view: string = 'month';
  viewDate: Date = new Date();
  events: CalendarEvent[]=[]; 
  excludeDays: number[] = [0, 6];
  weekDays = ["Monday","Tuesday","Wednesday","Thursday","Friday"];
  constructor(private shiftService: ShiftService) { }

   ngOnInit() {
     this.shiftService.schedule().subscribe(res => {
       this.shift = res;       
     })
   }  

   beforeMonthViewRender({ body }: { body: CalendarMonthViewDay[] }):void{ 
     this.shiftService.schedule().subscribe(res => {
       this.shift = res;
       let count = 0;
       body.forEach(day => {          
         //let days = this.shift.days.find(x => x.name == "Monday");
         if(day.date >= new Date()) {
          day.badgeTotal = 2;  
          let currentShift = this.shift.days[count++];   
          let engineers = currentShift.shifts[0].engineer.name + " And " + currentShift.shifts[1].engineer.name; 
          console.log(currentShift);
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

  //  generateShift() {
  //    for(let day of this.days){
  //      let event : CalendarEvent = {
  //       start: new Date('2018-01-01'),
  //       end: new Date('2018-01-01'),
  //       title: day.name,
  //       color: colors.red
  //      }
  //       this.events.push(event);       
  //    }
  //  }

  // events: CalendarEvent[] = [
  //   {
  //     start: new Date('2018-01-01'),
  //     end: new Date('2018-01-05'),
  //     title: 'One day excluded event',
  //     color: colors.red
  //   },
  //   {
  //     start: new Date('2018-01-01'),
  //     end: new Date('2018-01-05'),
  //     title: 'One day excluded event',
  //     color: colors.red
  //   },
  //   {
  //     start: new Date('2018-01-08'),
  //     end: new Date('2018-01-12'),
  //     title: 'Multiple weeks event',
  //     color: colors.colors
  //   }
  // ];

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
