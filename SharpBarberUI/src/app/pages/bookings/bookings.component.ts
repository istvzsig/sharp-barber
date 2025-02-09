import { Component } from '@angular/core';
import { BookingFormComponent } from "./form/bookingform.component";
import { FormsModule } from '@angular/forms';
import { BarberService } from '../../service/barber.service';

@Component({
  selector: 'app-bookins',
  templateUrl: './bookings.component.html',
  styleUrl: './bookings.component.scss',
  imports: [BookingFormComponent]
})
export class BookingsComponent {
  barbers: any = [];

  constructor(private barberService: BarberService) { }

  ngOnInit() {
    this.barbers = this.barberService.getBarbers();
  }
}
