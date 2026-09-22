import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  imports: [DatePipe],
  selector: 'app-pipes',
  styleUrl: './pipes.css',
  templateUrl: './pipes.html',
})
export class Pipes {
  todayDate: Date = new Date();
}
