import { MonthNumber } from "./Enums/MonthNumber";
import { WeekDayNumber } from "./Enums/WeekDayNumber";

export class WorkDate {
  private addDay(day: Date, incrementDays: number): Date {
    return new Date(day.getFullYear(), day.getMonth(), day.getDate() + incrementDays);
  }

  public getWeekDays(): Date[] {
    const result: Date[] = [];
    const now: Date = new Date;
    const weekDaysCount: number = 6;
    for (let i: number = 0; i < weekDaysCount; i++) {
      const weekDay: Date = this.addDay(now, i);
      result.push(weekDay);
    }

    return result;
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
