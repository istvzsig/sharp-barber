import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

interface Barber {
  id: string
  name: string
  imageUrl: string
}

@Component({
  selector: 'app-barber-selector',
  imports: [CommonModule],
  templateUrl: './barber-selector.component.html',
  styleUrl: './barber-selector.component.scss'
})
export class BarberSelectorComponent {
  @Input() barbers: Barber[] = [];
}
