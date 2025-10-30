import { TestBed } from '@angular/core/testing';

import { ComprobantecajaService } from './comprobantecaja.service';

describe('ComprobantecajaService', () => {
  let service: ComprobantecajaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComprobantecajaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
