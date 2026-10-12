import { Component, input, output } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-dhoni',
  styleUrl: './dhoni.css',
  templateUrl: './dhoni.html',
})
export class Dhoni {
  //@Input() itemValue: string = "";
  //@Output() dataEmmitter = new EventEmitter<string>();
  itemValue = input<string>();
  dataEmmitter =output<string>();
  
  sendData(value: string) {
    console.log("Data from dhoni: " + value);
    this.dataEmmitter.emit(value);
  }
}
