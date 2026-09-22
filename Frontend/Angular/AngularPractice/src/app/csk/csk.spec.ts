import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Csk } from './csk';

describe('Csk', () => {
  let component: Csk;
  let fixture: ComponentFixture<Csk>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Csk],
    }).compileComponents();

    fixture = TestBed.createComponent(Csk);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
