import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ComprobantecajaComponent } from './comprobantecaja.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ConfirmationService, MessageService } from 'primeng/api';

describe('ComprobantecajaComponent', () => {
  let component: ComprobantecajaComponent;
  let fixture: ComponentFixture<ComprobantecajaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ComprobantecajaComponent,
        NoopAnimationsModule
      ],
      providers: [
        ConfirmationService,
        MessageService
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(ComprobantecajaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
