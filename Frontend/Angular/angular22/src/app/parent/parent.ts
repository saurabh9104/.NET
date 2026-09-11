import { Component } from '@angular/core';
import { Child } from '../child/child';

@Component({
  imports: [Child],
  selector: 'app-parent',
  styleUrl: './parent.css',
  templateUrl: './parent.html',
})
export class Parent {
  name: string = "Saurabh";
  chhildData: string = "";

  getData(value: string) {
    console.log("Data from child: " + value);
    this.chhildData = value;

  }
}
