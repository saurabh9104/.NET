import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Rcb } from './rcb';

describe('Rcb', () => {
  let component: Rcb;
  let fixture: ComponentFixture<Rcb>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Rcb],
    }).compileComponents();

    fixture = TestBed.createComponent(Rcb);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
