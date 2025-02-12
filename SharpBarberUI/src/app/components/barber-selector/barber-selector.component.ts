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

  selectedBarberId: number | null = null;

  toggleSelected(barber: Barber) {
    this.selectedBarberId = this.selectedBarberId === barber.id ? null : barber.id;
    this.selectedBarber.emit(barber);
  }
}
