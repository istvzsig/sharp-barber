import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BarberSelectorComponent } from '../components/barber-selector/barber-selector.component';
import { Barber } from '../models/barber.model';

@Component({
  selector: 'app-bookingform',
  imports: [FormsModule, BarberSelectorComponent],
  templateUrl: './bookingform.component.html',
  styleUrl: './bookingform.component.scss'
})
export class BookingFormComponent {
  username: string = '';
  appointmentTime: string = '';
  selectedBarber: Barber | null = null;

  @Input() barbers: Barber[] = [];

  onBarberSelected(barber: Barber) {
    this.selectedBarber = barber;
  }

  onSubmit() {
    console.log('Booking:', {
      username: this.username,
      appointmentTime: this.appointmentTime,
      selectedBarber: this.selectedBarber,
    });
  }
}