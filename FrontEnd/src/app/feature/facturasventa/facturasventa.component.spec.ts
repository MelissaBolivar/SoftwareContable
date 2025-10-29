import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FacturasVentaComponent } from './facturasventa.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ConfirmationService, MessageService } from 'primeng/api';

describe('FacturasVentaComponent', () => {
  let component: FacturasVentaComponent;
  let fixture: ComponentFixture<FacturasVentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FacturasVentaComponent,
        NoopAnimationsModule
      ],
      providers: [
        ConfirmationService,
        MessageService
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(FacturasVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
