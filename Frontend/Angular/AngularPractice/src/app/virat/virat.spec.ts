import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Virat } from './virat';

describe('Virat', () => {
  let component: Virat;
  let fixture: ComponentFixture<Virat>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Virat],
    }).compileComponents();

    fixture = TestBed.createComponent(Virat);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
