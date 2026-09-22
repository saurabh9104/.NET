import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Mi } from './mi';

describe('Mi', () => {
  let component: Mi;
  let fixture: ComponentFixture<Mi>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Mi],
    }).compileComponents();

    fixture = TestBed.createComponent(Mi);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
