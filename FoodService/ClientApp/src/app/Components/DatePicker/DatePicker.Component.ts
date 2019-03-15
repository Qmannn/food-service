import { Component } from '@angular/core';

@Component({
  selector: 'app-date-picker',
  templateUrl: './DatePicker.Component.html',
  styleUrls: ['./DatePicker.Component.css']
})

export class DatePickerComponent {
  public getMonth(month): string {
    switch (month) {
      case 0: {
        return 'Января';
      }

      case 1: {
        return 'Февраля';
      }

      case 2: {
        return 'Марта';
      }

      case 3: {
        return 'Апреля';
      }

      case 4: {
        return 'Мая';
      }

      case 5: {
        return 'Июня';
      }

      case 6: {
        return 'Июля';
      }

      case 7: {
        return 'Августа';
      }

      case 8: {
        return 'Сентября';
      }

      case 9: {
        return 'Октября';
      }

      case 10: {
        return 'Ноября';
      }

      case 11: {
        return 'Декабря';
      }

      default: {
        return '';
      }
    }
  }

  public weekDayString(dayInWeek): string {
    switch (dayInWeek) {
      case 0: {
        return 'Воскресенье';
      }

      case 1: {
        return 'Понедельник';
      }

      case 2: {
        return 'Вторник';
      }

      case 3: {
        return 'Среда';
      }

      case 4: {
        return 'Четверг';
      }

      case 5: {
        return 'Пятница';
      }

      case 6: {
        return 'Суббота';
      }

      default: {
        return '';
      }
    }
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

  public addDay(day: Date, incrementDays: number): Date {
    return new Date(day.getFullYear(), day.getMonth(), day.getDate() + incrementDays);
  }

  private fillWeekDays(): Date[] {
    const result: Date[] = [];
    const now: Date = new Date;
    for (let i: number = 0; i < 6; i++) {
      const weekDay: Date = this.addDay(now, i);
      result.push(weekDay);
    }

    return result;
  }

  public weekDays: Date[] = this.fillWeekDays();

  //либо прокидывать дату, либо инкрементировать и прописать условие для дат в месяцах
}
