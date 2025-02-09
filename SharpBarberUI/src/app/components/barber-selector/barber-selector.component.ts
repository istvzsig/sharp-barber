import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Barber } from '../../models/barber.model';


@Component({
  selector: 'app-barber-selector',
  imports: [CommonModule],
  templateUrl: './barber-selector.component.html',
  styleUrl: './barber-selector.component.scss'
})
export class BarberSelectorComponent {
  @Input() barbers: Barber[] = [];
  @Output() selectedBarber = new EventEmitter<Barber>();

  toggleSelected(barber: Barber) {
    this.selectedBarber.emit(barber);
  }
}
