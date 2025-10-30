import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormularioComprobantecajaComponent } from './formulario-comprobantecaja.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MessageService } from 'primeng/api';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';

describe('FormularioComprobantecajaComponent', () => {
  let component: FormularioComprobantecajaComponent;
  let fixture: ComponentFixture<FormularioComprobantecajaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FormularioComprobantecajaComponent,
        NoopAnimationsModule // evita errores de animación en tests
      ],
      providers: [
        MessageService,
        { provide: DynamicDialogRef, useValue: {} },
        { provide: DynamicDialogConfig, useValue: { data: {} } }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(FormularioComprobantecajaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});