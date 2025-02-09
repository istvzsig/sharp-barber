import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BarberSelectorComponent } from "../../../components/barber-selector/barber-selector.component";

@Component({
  selector: 'app-bookingform',
  imports: [FormsModule, BarberSelectorComponent],
  templateUrl: './bookingform.component.html',
  styleUrl: './bookingform.component.scss'
})
export class BookingFormComponent {
  username: string = '';
  appointmentTime: string = '';

  @Input() barbers = [];

  onSubmit() {
    console.log('Booking:', {
      username: this.username,
      appointmentTime: this.appointmentTime
    });
  }
}