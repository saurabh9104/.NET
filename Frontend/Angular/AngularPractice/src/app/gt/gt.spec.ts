import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Gt } from './gt';

describe('Gt', () => {
  let component: Gt;
  let fixture: ComponentFixture<Gt>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Gt],
    }).compileComponents();

    fixture = TestBed.createComponent(Gt);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
