import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FacturasCompraComponent } from './facturascompra.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ConfirmationService, MessageService } from 'primeng/api';

describe('FacturasCompraComponent', () => {
  let component: FacturasCompraComponent;
  let fixture: ComponentFixture<FacturasCompraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FacturasCompraComponent,
        NoopAnimationsModule
      ],
      providers: [
        ConfirmationService,
        MessageService
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(FacturasCompraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
