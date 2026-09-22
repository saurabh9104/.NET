import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Hardik } from './hardik';

describe('Hardik', () => {
  let component: Hardik;
  let fixture: ComponentFixture<Hardik>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Hardik],
    }).compileComponents();

    fixture = TestBed.createComponent(Hardik);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
