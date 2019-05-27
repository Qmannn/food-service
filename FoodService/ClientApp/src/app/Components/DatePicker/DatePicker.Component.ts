import { AfterViewInit, ApplicationRef, Component, EventEmitter, Output } from '@angular/core';
import { DateHelper } from './DateHelper';
import { MonthNumber } from './MonthNumber';
import { WeekDayNumber } from './WeekDayNumber';

@Component({
  selector: 'app-date-picker',
  templateUrl: './DatePicker.Component.html',
  styleUrls: ['./DatePicker.Component.css']
})

export class DatePickerComponent implements AfterViewInit {
  private firstDate: Date;
  protected selectedDate: Date;
  protected dateHelper: DateHelper;
  protected weekDays: Date[];

  private now: Date;

  @Output()
  public dateSelected: EventEmitter<Date> = new EventEmitter<Date>();

  public constructor() {
      this.now = new Date();
      this.firstDate = this.now;
      this.selectedDate = this.now;
      this.dateHelper = new DateHelper();
      this.weekDays = this.dateHelper.getWeekDays(this.firstDate);
  }

  public ngAfterViewInit(): void {
    this.dateSelected.emit(this.selectedDate);
  }

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

  public nextWeek(): void {
    const weeksCount: number = 1;
    this.firstDate = this.dateHelper.addWeek(this.firstDate, weeksCount);
    this.weekDays = this.dateHelper.getWeekDays(this.firstDate);
  }

  public prevWeek(): void {
    const weeksCount: number = -1;
    this.firstDate = this.dateHelper.addWeek(this.firstDate, weeksCount);
    this.weekDays = this.dateHelper.getWeekDays(this.firstDate);
  }

  protected getStyle(day: Date): string {
    return this.dateHelper.isEqualsDate(this.selectedDate, day) ? 'selected-date' : '';
  }
}
