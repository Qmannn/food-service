import { Component } from '@angular/core';

@Component({
  selector: 'app-date-picker',
  templateUrl: './DatePicker.Component.html',
  styleUrls: ['./DatePicker.Component.css']
})

export class DatePickerComponent {
  public selectDate: Date = new Date;

  public month: number = this.selectDate.getMonth();

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

  public getWeekDay(weekDay): string {
    switch (weekDay) {
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

  public getWeekResultDay(weekDay): number {
    if (weekDay > 6) {
      weekDay = weekDay - 7;
      return weekDay;
    } else {
      return weekDay;
    }
  }

  public count: number = 1;

  public addDay(day: Date, counter: number): void {
    day.setDate(day.getDate() + counter);
  }

  public dateNow: Date = this.addDay(this.selectDate, this.count);

  public weekDay: number = this.dateNow.getDay();

  public weekDays = [this.weekDay, this.weekDay + 1, this.weekDay + 2, this.weekDay + 3, this.weekDay + 4, this.weekDay + 5];

  //либо прокидывать дату, либо инкрементировать и прописать условие для дат в месяцах

  public onClickDate(datePick: number) {
    alert(this.getWeekDay(this.getWeekResultDay(datePick)));
  };
}
