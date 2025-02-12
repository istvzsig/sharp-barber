import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { BarberSelectorComponent } from '../components/barber-selector/barber-selector.component';
import { Barber } from '../models/barber.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bookingform',
  imports: [CommonModule, FormsModule, ReactiveFormsModule, BarberSelectorComponent],
  templateUrl: './bookingform.component.html',
  styleUrl: './bookingform.component.scss'
})
export class BookingFormComponent {
  @Input() barbers: Barber[] = [];

  bookingForm: FormGroup;
  selectedBarber: Barber | null = null;

  constructor(private formBuilder: FormBuilder) {
    this.bookingForm = this.formBuilder.group({
      username: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(13),
          Validators.pattern('^[a-zA-Z0-9_-]*$')
        ]
      ],
      appointmentTime: ['', [Validators.required, futureDateValidator]],
      barberId: [null, [notNullValidator()]]
    })
  }

  onBarberSelected(barber: Barber) {
    this.selectedBarber = this.selectedBarber !== barber ? barber : null;
    this.bookingForm.patchValue({ barberId: this.selectedBarber?.id || null });
  }

  onSubmit() {
    // TODO: Add additional validation and error handling
    console.log('Booking:', this.bookingForm.value);
  }
}

export function futureDateValidator(control: FormControl): Object | null {
  const selectedDate = new Date(control.value);
  const now = new Date();
  return selectedDate > now ? null : { pastDate: true };
}

export function notNullValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    return control.value !== null && control.value !== undefined
      ? null
      : { notNull: true };
  };
}