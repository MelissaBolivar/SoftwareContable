import { TestBed } from '@angular/core/testing';

import { FacturasCompraService } from './facturascompra.service';

describe('FacturasCompraService', () => {
  let service: FacturasCompraService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FacturasCompraService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
