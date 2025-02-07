import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'SharpBarberUI';
  barbers: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getBarbers();
  }

  getBarbers(): void {
    this.http.get<any[]>('http://localhost:5193/api/barbers').subscribe(
      (data) => {
        this.barbers = data;
        console.log(this.barbers);
      },
      (error) => {
        console.error('Error fetching barbers', error);
      }
    );
  }
}
