import { TestBed } from '@angular/core/testing';

import { FacturasVentaService } from './facturasventa.service';

describe('FacturasVentaService', () => {
  let service: FacturasVentaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FacturasVentaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
