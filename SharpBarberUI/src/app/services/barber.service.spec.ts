import { TestBed } from '@angular/core/testing';

import { BarberService } from './barber.service';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('BarberService', () => {
  let service: BarberService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpClient, HttpHandler]
    });
    service = TestBed.inject(BarberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
