import { Component } from '@angular/core';
import { BookingFormComponent } from "./form/bookingform.component";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-bookins',
  templateUrl: './bookings.component.html',
  styleUrl: './bookings.component.scss',
  imports: [BookingFormComponent]
})
export class BookinsComponent {

}
