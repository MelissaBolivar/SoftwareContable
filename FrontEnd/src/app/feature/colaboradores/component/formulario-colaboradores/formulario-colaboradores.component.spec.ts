import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioColaboradoresComponent } from './formulario-colaboradores.component';

describe('FormularioColaboradoresComponent', () => {
  let component: FormularioColaboradoresComponent;
  let fixture: ComponentFixture<FormularioColaboradoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioColaboradoresComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioColaboradoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
