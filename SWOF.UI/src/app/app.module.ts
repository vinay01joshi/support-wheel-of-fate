import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http';

import { CalendarModule } from 'angular-calendar';
import { AppComponent } from './app.component';

import { ShiftComponent } from './shift/shift.component';
import { ShiftService } from './services/shift.service';


@NgModule({
  declarations: [
    AppComponent,    
    ShiftComponent   
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CalendarModule.forRoot(),    
  ],
  providers: [ShiftService],
  bootstrap: [AppComponent],
  exports: [AppComponent]
})
export class AppModule { }
