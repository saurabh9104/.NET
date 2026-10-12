import { Component, EventEmitter, output } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-signup',
  styleUrl: './signup.css',
  templateUrl: './signup.html',
})
export class Signup {
  loginRequested = output<void>();

  gotologin(){

    this.loginRequested.emit();
  }
}
