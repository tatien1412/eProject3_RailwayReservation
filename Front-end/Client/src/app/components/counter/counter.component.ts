import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  templateUrl: './counter.component.html',
  styleUrl: './counter.component.css'
})
export class CounterComponent {
  value: number = 0;

  increase() {
    this.value++;
  }

  decrease() {
    if (this.value > 1) {
      this.value--;
    }
  }
}
