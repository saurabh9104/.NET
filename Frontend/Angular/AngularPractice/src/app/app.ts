import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Gt } from './gt/gt';
import { Csk } from './csk/csk';
import { Mi } from './mi/mi';
import { Rcb } from './rcb/rcb';

@Component({
  imports: [Csk, Mi, Rcb, Gt],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  
}
