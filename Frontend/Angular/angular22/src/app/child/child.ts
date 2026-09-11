import { Component, EventEmitter, Input, input, Output } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-child',
  styleUrl: './child.css',
  templateUrl: './child.html',
})
export class Child {
  @Input() itemValue: string = "";
  @Output() dataEmmitter = new EventEmitter<string>();

  sendData(value: string) {
    console.log("Data from child: " + value);
    this.dataEmmitter.emit(value);
  }


}
