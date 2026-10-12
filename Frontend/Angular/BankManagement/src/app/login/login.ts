import { Component, EventEmitter, output } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {

  signupRequested = output<void>();
  gotosignup(){
    
    this.signupRequested.emit();

  }
}
