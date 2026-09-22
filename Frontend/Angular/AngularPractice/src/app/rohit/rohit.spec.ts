import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Rohit } from './rohit';

describe('Rohit', () => {
  let component: Rohit;
  let fixture: ComponentFixture<Rohit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Rohit],
    }).compileComponents();

    fixture = TestBed.createComponent(Rohit);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
