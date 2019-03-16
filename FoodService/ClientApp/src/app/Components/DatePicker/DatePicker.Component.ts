import { Component } from '@angular/core';
import { WorkDate } from './WorkDate';

@Component({
  selector: 'app-date-picker',
  templateUrl: './DatePicker.Component.html',
  styleUrls: ['./DatePicker.Component.css']
})

export class DatePickerComponent {
  public workDate: WorkDate = new WorkDate();

  public monthString(numMonth: number): string {
    return this.workDate.getMonthString(numMonth);
  }

  public weekDayString(numWeekDay: number): string {
    return this.workDate.weekDayString(numWeekDay);
  }

  public getWeekDay(day: Date): number {
    return day.getDay();
  }

  public getNumDay(day: Date): number {
    return day.getDate();
  }

  public getMonthDay(day: Date): number {
    return day.getMonth();
  }

  public weekDays: Date[] = this.workDate.fillWeekDays();

  public onClickDate(day: Date): void {
    alert(day.getDate() + ' ' + this.workDate.getMonthString(day.getMonth()) + ' ' + day.getFullYear());
  }
}
