import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { UserService } from '../../../../shared/Service/user/user.service';
import { InformationUser, TipoIdentificacion } from '../../../../shared/interfaces/InformationUser.interface';
import { InputTextModule } from 'primeng/inputtext';
import { MessageService } from 'primeng/api';
import { RegularExpressions } from '../../../../shared/constant/regex';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ProveedorService } from '../../../../shared/Service/proveedor/proveedor.service';
import { CreateOrUpdateProveedor } from '../../../../shared/interfaces/CreateOrUpdateProveedor.interface';

@Component({
  selector: 'app-formulario-proveedores',
  standalone: true,
  imports: [
    InputTextModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    CalendarModule,
    ConfirmDialogModule,
    DropdownModule,
    ProgressSpinnerModule
  ],
  templateUrl: './formulario-proveedores.component.html',
  styleUrl: './formulario-proveedores.component.scss'
})
export class FormularioProveedoresComponent {
  componentForm: FormGroup;
  requiredField = 'Campo obligatorio';
  headerName = '';
  action = '';
  id= '';
  loading = false;

  possitiveNumberInt = 'Debe ser un número entero positivo';
  possitiveNumberIntGreatZero = 'Debe ser un número mayor o igual a cero';
  possitiveNumberIntGreat2020 = 'Debe ser un número mayor o igual a 2020';
  possitiveNumberIntGreatOne = 'Debe ser un número mayor o igual a uno';
  possitiveNumberIntLessTwelve = 'Debe ser un número menor o igual a doce';

  listUser: TipoIdentificacion[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private readonly service: ProveedorService,
    private readonly userService: UserService,
    private readonly messageService: MessageService,
  ) {
    this.componentForm = this.formBuilder.group({
      tipoDocumentoId: ['', Validators.required],
      numeroDocumento: ['', Validators.required],
      razonSocial: ['', Validators.required],
      direccion: ['', Validators.required],
      telefono: ['', Validators.required],
      correo: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.loadInformation();

    this.action = this.config.data.action;
    this.headerName = this.config.data.name;
    if (this.action === 'actualizar'){
      this.id = this.config.data.id;
      this.componentForm.patchValue({
        month: this.config.data.month,
        year: this.config.data.year,
        amount: this.config.data.amount,
        userId: this.config.data.userId,
        numeroDocumento: this.config.data.numeroDoc,
        tipoDocumentoId: parseInt(this.config.data.tipoDocId),
        razonSocial: this.config.data.razonSocialTercero,
        direccion: this.config.data.direccionTercero,
        telefono: this.config.data.telefonoTercero,
        correo: this.config.data.correoElectronicoTercero
      });
    }
  }

  loadInformation(){
    this.getUser();
  }

  getUser(){
    this.loading = true;
    this.userService.getListTiposDocumentos().subscribe({
      next: response => {
        this.loading = false;
        this.listUser = response;
      },
      error: (error) => {
        this.loading = false;
        this.showError(error);
      }
    });
  }

  onSubmit() {
    if (this.componentForm.valid) {
      this.loading = true;

      // Normalizar NumeroDocumento antes de enviar
      const normalizedNumero = this.normalizeNumeroDocumento(this.componentForm.value.numeroDocumento);
      // Actualizar el value en el form para que quede consistente visualmente
      this.componentForm.controls['numeroDocumento'].setValue(normalizedNumero);

      if(this.action === 'Crear') {
        const createParser = this.createParserFormData();
        this.service.create(createParser).subscribe({
          next: () => {
            this.loading = false;
            this.onClose();
          }, error: (error) => {
            this.loading = false;
            this.handleApiError(error, 'numeroDocumento');
          }
        });
      } else{
        const updateParser = this.updateParserFormData();
        this.service.update(updateParser).subscribe({
          next: () => {
            this.loading = false;
            this.onClose();
          }, error: (error) => {
            this.loading = false;
            this.handleApiError(error, 'numeroDocumento');
          }
        });
      }
    } else {
      // Marcar todos como touched para mostrar errores en el form si el usuario intenta avanzar
      this.componentForm.markAllAsTouched();
    }
  }

  onClose() {
    this.componentForm.reset();
    this.ref.close();
  }

  private createParserFormData(): CreateOrUpdateProveedor{
    return {
      TerceroId: null,
      TipoDocId: this.componentForm.value.tipoDocumentoId,
      NumeroDoc: this.componentForm.value.numeroDocumento,
      RazonSocialTercero: this.componentForm.value.razonSocial,
      DireccionTercero: this.componentForm.value.direccion,
      TelefonoTercero: this.componentForm.value.telefono,
      CorreoElectronicoTercero: this.componentForm.value.correo,
      TipoTerceroId: 1
    }
  }

  private updateParserFormData():CreateOrUpdateProveedor{
    return {
      TerceroId: Number.parseInt(this.id),
      TipoDocId: this.componentForm.value.tipoDocumentoId,
      NumeroDoc: this.componentForm.value.numeroDocumento,
      RazonSocialTercero: this.componentForm.value.razonSocial,
      DireccionTercero: this.componentForm.value.direccion,
      TelefonoTercero: this.componentForm.value.telefono,
      CorreoElectronicoTercero: this.componentForm.value.correo,
      TipoTerceroId: 1
    }
  }

  /**
   * Normaliza el número de documento:
   * - trim()
   * - convertir a mayúsculas para evitar diferencias de casing
   */
  private normalizeNumeroDocumento(value: string | null | undefined): string {
    if (!value) return '';
    return value.toString().trim().toUpperCase();
  }

  /**
   * Manejo de errores del API: si la API devuelve 400 con mensaje de
   * unicidad ("mensaje"), mostramos alert y establecemos error en el campo correspondiente
   */
  private handleApiError(error: any, controlName: string): void {
    // Primero intenta mapear el mensaje enviado por el API (usamos 'mensaje' según tu backend)
    const apiMessage = error?.error?.mensaje ?? error?.error?.message ?? null;

    if (error?.status === 400 && apiMessage) {
      // Poner error en el control para que el formulario no permita avanzar
      const control = this.componentForm.get(controlName);
      if (control) {
        control.setErrors({ exists: true });
        control.markAsTouched();
      }

      // Mostrar toast con el mensaje enviado por el backend
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: apiMessage,
      });
      return;
    }

    // Si no es un 400 esperado, delegar a showError para mensajes genéricos
    this.showError(error);
  }

  private showError(error: any): void {
    const apiMessage = error?.error?.mensaje ?? error?.error?.message ?? null;

    if (apiMessage) {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: apiMessage,
      });
    } else {
      this.showMessage('error', 'Error', 'Algo salió mal, intente de nuevo');
    }
  }

  private showMessage(severity: 'success' | 'info' | 'warn' | 'error', summary: string, detail: string): void {
    this.messageService.add({ severity, summary, detail });
  }
}

