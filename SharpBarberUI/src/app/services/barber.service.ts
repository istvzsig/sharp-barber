// barbers.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BarberService {

  constructor(private http: HttpClient) { }

  getBarbers() {
    // TODO: Add api call /barbers
    return [
      {
        id: 1,
        name: "test-barber-1",
      },
      {
        id: 2,
        name: "test-barber-2",
      },
    ]
  }
}
