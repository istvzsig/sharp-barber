import { Routes } from '@angular/router';

import { NotFoundComponent } from './not-found/not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { BookinsComponent } from './pages/bookins/bookins.component';

export const routes: Routes = [
    { path: "", component: HomeComponent },
    { path: "bookings", component: BookinsComponent },
    { path: '**', component: NotFoundComponent },
];

