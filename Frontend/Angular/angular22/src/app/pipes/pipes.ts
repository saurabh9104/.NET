import { DatePipe, NgClass } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  imports: [DatePipe, NgClass],
  selector: 'app-pipes',
  styleUrl: './pipes.css',
  templateUrl: './pipes.html',
})
export class Pipes {
  todayDate: Date = new Date();
  isdark: boolean = false;
  switch(){
    this.isdark = !this.isdark;
  }
}
