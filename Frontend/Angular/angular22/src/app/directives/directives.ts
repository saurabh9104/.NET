import { NgIf } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  imports: [NgIf],
  selector: 'app-directives',
  styleUrl: './directives.css',
  templateUrl: './directives.html',
})
export class Directives {
  isvisible: boolean = true;
}
