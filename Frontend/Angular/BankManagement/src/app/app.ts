import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Login } from './login/login';
import { Signup } from './signup/signup';

@Component({
  imports: [Login, Signup],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  showLogin = true;

  showRegister() {
    this.showLogin = false;
  }

  showLoginPage() {
    this.showLogin = true;
  }
}
