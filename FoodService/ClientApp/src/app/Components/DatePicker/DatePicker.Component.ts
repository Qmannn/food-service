import { Component, EventEmitter, Output } from '@angular/core';
import { DateHelper } from './DateHelper';
import { MonthNumber } from './MonthNumber';
import { WeekDayNumber } from './WeekDayNumber';

@Component({
  selector: 'app-date-picker',
  templateUrl: './DatePicker.Component.html',
  styleUrls: ['./DatePicker.Component.css']
})

export class DatePickerComponent {
  private now: Date = new Date();

  protected dateHelper: DateHelper = new DateHelper();
  protected weekDays: Date[] = this.dateHelper.getWeekDays(this.now);

  @Output()
  public dateSelected: EventEmitter<Date> = new EventEmitter<Date>();
  protected selectedDate: Date = this.now;

  public monthString(numMonth: MonthNumber): string {
    return this.dateHelper.getMonthString(numMonth);
  }

  public weekDayString(numWeekDay: WeekDayNumber): string {
    return this.dateHelper.weekDayString(numWeekDay);
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

  public onClickDate(day: Date): void {
    this.dateSelected.emit(day);
    this.selectedDate = day;
  }

  protected getStyle(day: Date): string {
    return this.dateHelper.isEqualsDate(this.selectedDate, day) ? 'selected-date' : '';
  }
}
