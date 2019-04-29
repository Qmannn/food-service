import { MonthNumber } from './MonthNumber';
import { WeekDayNumber } from './WeekDayNumber';

export class DateHelper {
  private static readonly _weekLenth: number = 7;
  private addDay(day: Date, incrementDays: number): Date {
    return new Date(day.getFullYear(), day.getMonth(), day.getDate() + incrementDays);
  }

  public isEqualsDate(date1: Date, date2: Date): boolean {
    return date1.getFullYear() === date2.getFullYear() && date1.getMonth() === date2.getMonth() && date1.getDate() === date2.getDate();
  }

  public getWeekDays(date: Date): Date[] {
    const result: Date[] = [];
    const weekDaysCount: number = 6;
    let differenceWeekDays: number;

    if (date.getDay() === WeekDayNumber.Sunday) {
      differenceWeekDays = -WeekDayNumber.Monday;
    } else {
      differenceWeekDays = date.getDay() - WeekDayNumber.Monday;
    }

    for (let i: number = 0; i < weekDaysCount; i++) {
      const weekDay: Date = this.addDay(date, i - differenceWeekDays);
      result.push(weekDay);
    }

    return result;
  }

  public offsetWeek(day: Date, isBefore: boolean): Date {
    const factor: number = isBefore ? -1 : 1;

    return new Date(day.getFullYear(), day.getMonth(), day.getDate() + factor * DateHelper._weekLenth);
  }

  public getMonthString(month: MonthNumber): string {
    switch (month) {
      case MonthNumber.January: {
        return 'Января';
      }

      case MonthNumber.February: {
        return 'Февраля';
      }

      case MonthNumber.March: {
        return 'Марта';
      }

      case MonthNumber.April: {
        return 'Апреля';
      }

      case MonthNumber.May: {
        return 'Мая';
      }

      case MonthNumber.June: {
        return 'Июня';
      }

      case MonthNumber.July: {
        return 'Июля';
      }

      case MonthNumber.August: {
        return 'Августа';
      }

      case MonthNumber.September: {
        return 'Сентября';
      }

      case MonthNumber.October: {
        return 'Октября';
      }

      case MonthNumber.November: {
        return 'Ноября';
      }

      case MonthNumber.December: {
        return 'Декабря';
      }

      default: {
        return '';
      }
    }
  }

  public weekDayString(dayInWeek: WeekDayNumber): string {
    switch (dayInWeek) {
      case WeekDayNumber.Sunday: {
        return 'Воскресенье';
      }

      case WeekDayNumber.Monday: {
        return 'Понедельник';
      }

      case WeekDayNumber.Tuesday: {
        return 'Вторник';
      }

      case WeekDayNumber.Wednesday: {
        return 'Среда';
      }

      case WeekDayNumber.Thursday: {
        return 'Четверг';
      }

      case WeekDayNumber.Friday: {
        return 'Пятница';
      }

      case WeekDayNumber.Saturday: {
        return 'Суббота';
      }

      default: {
        return '';
      }
    }
  }
}
