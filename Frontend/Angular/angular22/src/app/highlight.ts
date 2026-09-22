import { Directive, ElementRef, inject, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
})
export class Highlight {
  private el = inject(ElementRef);
private render = inject(Renderer2);

constructor(){
this.render.setStyle(this.el.nativeElement, 'backgroundColor', 'yellow');
this.render.setStyle(this.el.nativeElement, 'color', 'red');
this.render.setProperty(this.el.nativeElement, 'innerHTML', 'this is highlight');
}
}
