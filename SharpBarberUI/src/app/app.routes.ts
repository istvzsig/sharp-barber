import { Routes } from '@angular/router';

import { NotFoundComponent } from './not-found/not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { BookingsComponent } from './pages/bookings/bookings.component';

export const routes: Routes = [
    { path: "", component: HomeComponent },
    { path: "bookings", component: BookingsComponent },
    { path: '**', component: NotFoundComponent },
];

