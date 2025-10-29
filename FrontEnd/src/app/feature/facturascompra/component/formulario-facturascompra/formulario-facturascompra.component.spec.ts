import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormularioFacturasCompraComponent } from './formulario-facturascompra.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MessageService } from 'primeng/api';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';

describe('FormularioFacturasCompraComponent', () => {
  let component: FormularioFacturasCompraComponent;
  let fixture: ComponentFixture<FormularioFacturasCompraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FormularioFacturasCompraComponent,
        NoopAnimationsModule // evita errores de animación en tests
      ],
      providers: [
        MessageService,
        { provide: DynamicDialogRef, useValue: {} },
        { provide: DynamicDialogConfig, useValue: { data: {} } }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(FormularioFacturasCompraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});