import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
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
  bookingForm: FormGroup;
  selectedBarber: Barber | null = null;

  @Input() barbers: Barber[] = [];

  constructor(private fb: FormBuilder) {
    this.bookingForm = this.fb.group({
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
      selectedBarber: [null, [Validators.required]]
    })
  }

  onBarberSelected(barber: Barber) {
    this.selectedBarber = barber;
    this.bookingForm.patchValue({ selectedBarber: barber });
  }

  onSubmit() {
    if (this.bookingForm.valid) {
      console.log('Booking:', this.bookingForm.value);
    } else {
      console.error('Form is invalid');
    }
  }
}

function futureDateValidator(control: FormControl) {
  const selectedDate = new Date(control.value);
  const now = new Date();
  return selectedDate > now ? null : { pastDate: true };
}