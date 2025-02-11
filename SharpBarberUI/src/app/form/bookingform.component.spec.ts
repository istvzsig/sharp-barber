import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BookingFormComponent } from './bookingform.component';
import { ReactiveFormsModule } from '@angular/forms';

describe('BookingFormComponent', () => {
  let component: BookingFormComponent;
  let fixture: ComponentFixture<BookingFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, BookingFormComponent],
      declarations: []
    }).compileComponents();

    fixture = TestBed.createComponent(BookingFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should be invalid when fields are empty', () => {
    expect(component.bookingForm.valid).toBeFalsy();
  });

  it('should be valid when required fields are filled', () => {
    component.bookingForm.controls['username'].setValue('JohnDoe');
    component.bookingForm.controls['appointmentTime'].setValue('2025-02-12T10:00');
    component.bookingForm.controls['selectedBarber'].setValue(1);

    expect(component.bookingForm.valid).toBeTruthy();
  });

  it('should call onSubmit when form is valid', () => {
    spyOn(component, 'onSubmit');

    component.bookingForm.controls['username'].setValue('JohnDoe');
    component.bookingForm.controls['appointmentTime'].setValue('2025-02-12T10:00');
    component.bookingForm.controls['selectedBarber'].setValue(1);

    fixture.detectChanges();
    component.onSubmit();

    expect(component.onSubmit).toHaveBeenCalled();
  });
});
