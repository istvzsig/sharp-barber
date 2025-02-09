import { Component } from '@angular/core';
import { BarberService } from '../../services/barber.service';
import { Barber } from '../../models/barber.model';
import { BookingFormComponent } from '../../form/bookingform.component';

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
