import { Component } from '@angular/core';
import { Dhoni } from '../dhoni/dhoni';

@Component({
  imports: [Dhoni],
  selector: 'app-csk',
  styleUrl: './csk.css',
  templateUrl: './csk.html',
})
export class Csk {
  employee = {
    name: 'MS Dhoni',
    role: 'captain',
    experience: 12
  };
 

  getData(value: string) {
    console.log("Data from dhoni: " + value);
    this.employee.role = value;

  }
}
