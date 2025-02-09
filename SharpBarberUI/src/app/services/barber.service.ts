import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';
import { Barber } from '../models/barber.model';

@Injectable({
  providedIn: 'root',
})
export class BarberService {
  private apiUrl = 'http://localhost:5193/api/barbers';

  constructor(private http: HttpClient) { }

  getBarbers(): Observable<Barber[]> {
    return this.http.get<Barber[]>(this.apiUrl).pipe(
      catchError(error => {
        console.error('Error fetching barbers:', error);
        return of([]);
      })
    );
  }
}
