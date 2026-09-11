import { Component, EventEmitter, Input, input, output, Output } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-child',
  styleUrl: './child.css',
  templateUrl: './child.html',
})
export class Child {
  //@Input() itemValue: string = "";
  //@Output() dataEmmitter = new EventEmitter<string>();
  itemValue = input<string>();
  dataEmmitter =output<string>();
  
  sendData(value: string) {
    console.log("Data from child: " + value);
    this.dataEmmitter.emit(value);
  }


}
