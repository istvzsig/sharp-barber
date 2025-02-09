import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-found',
  template: `
    <h1>404 - Page Not Found</h1>
    <p>Redirecting you to the homepage...</p>
  `,
  styleUrls: ['./not-found.component.scss']
})
export class NotFoundComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    // Set a delay and then redirect to the home page
    setTimeout(() => {
      this.router.navigate(['/']);
    }, 3000); // Delay for 3 seconds before redirecting
  }
}
