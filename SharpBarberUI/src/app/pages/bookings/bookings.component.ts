import { Component } from '@angular/core';
import { BookingFormComponent } from "./form/bookingform.component";
import { FormsModule } from '@angular/forms';
import { BarberService } from '../../services/barber.service';
import { Barber } from '../../models/barber.model';

@Component({
  selector: 'app-bookins',
  templateUrl: './bookings.component.html',
  styleUrl: './bookings.component.scss',
  imports: [BookingFormComponent]
})
export class BookingsComponent {
  barbers: Barber[] = [];

  constructor(private barberService: BarberService) { }

  ngOnInit() {
    this.barberService.getBarbers().subscribe({
      next: (data) => this.barbers = data,
      error: (err) => console.error('Failed to load barbers:', err)
    });
  }
}
