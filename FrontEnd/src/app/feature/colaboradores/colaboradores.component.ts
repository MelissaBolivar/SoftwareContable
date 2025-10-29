import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { FieldFilter } from '../../shared/interfaces/FieldFilter.interface';
import { ConfirmationService, MessageService } from 'primeng/api';
import { HttpService } from '../../shared/Service/http-service/http.service';
import { UserService } from '../../shared/Service/user/user.service';
import { InputTextModule } from 'primeng/inputtext';
import { Colaborador } from '../../shared/interfaces/colaborador.interface';
import { ColaboradorService } from '../../shared/Service/colaborador/colaborador.service';
import { FormularioColaboradoresComponent } from './component/formulario-proveedores/formulario-colaboradores.component';

@Component({
  selector: 'app-colaboradores',
  standalone: true,
  imports: [
      FormsModule,
      CommonModule,
      ReactiveFormsModule,
      TableModule,
      ButtonModule,
      CalendarModule,
      ConfirmDialogModule,
      InputTextModule
    ],
    providers:[
      DialogService,
      ConfirmationService,
      ColaboradorService,
      HttpService,
      UserService
    ],
  templateUrl: './colaboradores.component.html',
  styleUrl: './colaboradores.component.scss'
})
export class ColaboradoresComponent {
infoTable!: Colaborador[];
  loading = true;
  ref!: DynamicDialogRef;
  filters: FieldFilter[] = [];

  constructor(
    private readonly service: ColaboradorService, 
    public dialogService: DialogService,
    private readonly confirmationService: ConfirmationService,
    private readonly messageService: MessageService         
  ) {}
  
  ngOnInit() {
    this.getinfoTable();
  } 
  
  getinfoTable(){
    //this.service.getList(this.filters).subscribe({
    this.service.getList().subscribe({
      next: (response: Colaborador[]) => {
        this.infoTable = response;
        this.loading = false;                
      }, 
      error: (error) => {
        this.loading = false;
        this.showError(error);
      }
    })
  }
    
  delete(
    infoComponent: Colaborador
  )
  {
this.service.delete(parseInt(infoComponent.terceroId)).subscribe({
    next: () => {
      alert('Colaborador eliminado correctamente');
      this.getinfoTable()
      // Aquí puedes recargar la lista o actualizar la vista
    },
    error: (err) => {
      alert('Error eliminando el colaborador:');
    }
  });
  }
  new(){
    this.ref = this.dialogService.open(FormularioColaboradoresComponent, {
      data: { action:'crear' },
      width: '90%',
      height: '100%',
      contentStyle: { "max-height": "700px", "overflow": "auto" },
      dismissableMask: true 
    });

    this.ref.onClose.subscribe(() => {      
        this.getinfoTable();      
    });
    
  }
    
  edit(
    infoComponent: Colaborador
  ){
    this.ref = this.dialogService.open(FormularioColaboradoresComponent, {
      data: { 
        action:'actualizar',
        id: infoComponent.terceroId,
        tipoDocId:infoComponent.tipoDocId,
        userId: infoComponent.userId,
        userName: infoComponent.userName,
        expenseTypeId: infoComponent.expenseTypeId,
        expenseTypeName: infoComponent.expenseTypeName,
        month: infoComponent.month,
        year: infoComponent.year,
        amount: infoComponent.amount,
        numeroDoc:infoComponent.numeroDoc,
        razonSocialTercero:infoComponent.razonSocialTercero,
        direccionTercero:infoComponent.direccionTercero, 
        telefonoTercero:infoComponent.telefonoTercero, 
        correoElectronicoTercero:infoComponent.correoElectronicoTercero, 
           
      },
      width: '90%',
      height: '100%',
      contentStyle: { "max-height": "700px", "overflow": "auto" },
      dismissableMask: true 
    });

    this.ref.onClose.subscribe(() => {      
      this.getinfoTable();      
    });
  }
  
  onColumnFilter(event: Event, field: string) {
    const input = event.target as HTMLInputElement;
    const value = input.value.trim();

    const data = {
      field: field,
      value : value
    }

    const indiceExist = this.filters.findIndex(item => item.field === data.field);

    if(indiceExist !== -1) {
      this.filters.splice(indiceExist, 1);
    }

    if(data.value){
      this.filters.push(data);
    }

    this.getinfoTable(); 
  }  

  private showError(error: any): void {
    if(error?.status === 400)
    {              
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: error.error.message,
      });
    }
    else{
      this.showMessage('error', 'Error', 'Algo salió mal, intente de nuevo');
    }   
  }

  private showMessage(severity: 'success' | 'info' | 'warn' | 'error', summary: string, detail: string): void {
    this.messageService.add({ severity, summary, detail });
  }

}
