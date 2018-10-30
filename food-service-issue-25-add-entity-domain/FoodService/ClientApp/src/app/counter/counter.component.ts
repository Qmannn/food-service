import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount: number = 0;

  public incrementCounter(): void {
    this.currentCount++;
  }
}
