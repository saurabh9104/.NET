import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Dhoni } from './dhoni';

describe('Dhoni', () => {
  let component: Dhoni;
  let fixture: ComponentFixture<Dhoni>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Dhoni],
    }).compileComponents();

    fixture = TestBed.createComponent(Dhoni);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
