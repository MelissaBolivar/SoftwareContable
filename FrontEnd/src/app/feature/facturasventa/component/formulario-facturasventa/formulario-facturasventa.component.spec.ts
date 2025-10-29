import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormularioFacturasVentaComponent } from './formulario-facturasventa.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MessageService } from 'primeng/api';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';

describe('FormularioFacturasVentaComponent', () => {
  let component: FormularioFacturasVentaComponent;
  let fixture: ComponentFixture<FormularioFacturasVentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FormularioFacturasVentaComponent,
        NoopAnimationsModule // evita errores de animación en tests
      ],
      providers: [
        MessageService,
        { provide: DynamicDialogRef, useValue: {} },
        { provide: DynamicDialogConfig, useValue: { data: {} } }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(FormularioFacturasVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});