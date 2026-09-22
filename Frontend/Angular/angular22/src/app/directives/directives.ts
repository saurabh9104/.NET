import { NgIf, NgStyle } from '@angular/common';
import { Component } from '@angular/core';
import { Highlight } from '../highlight';

@Component({
  imports: [NgStyle,Highlight],
  selector: 'app-directives',
  styleUrl: './directives.css',
  templateUrl: './directives.html',
})
export class Directives {
  isvisible: boolean = true;
  istrue: boolean = false;
}
