import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ToolbarModule } from "primeng/toolbar";
import { AvatarModule } from "primeng/avatar";
import { CommonModule } from "@angular/common";
import { SidebarModule } from 'primeng/sidebar';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';
import { MenuItem } from 'primeng/api';
import { PanelMenuModule } from 'primeng/panelmenu';

@Component({
  selector: 'app-header',  
  standalone: true,
  imports: [
    CommonModule,
    SidebarModule,    
    AvatarModule,
    ButtonModule,
    DividerModule,
    ToolbarModule,
    PanelMenuModule 
  ],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class HeaderComponent implements OnInit{
  sidebarVisible = false;
  dropdownVisible = false;
  userName = '';
  isLogged= true;

  menuItems: MenuItem[] = [
  {
    label: 'Facturas',
    items: [
      { label: 'Facturas de Venta', routerLink: ['/facturasventa'] },
      { label: 'Facturas de Compra', routerLink: ['/facturascompra'] },
      { label: 'Comprobante de Caja', routerLink: ['/comprobantecaja'] }
    ]
  },
  {
    label: 'Terceros',
    items: [
      { label: 'Proveedores', routerLink: ['/Proveedores'] },
      { label: 'Clientes', routerLink: ['/Clientes'] },
      { label: 'Colaboradores', routerLink: ['/Colaboradores'] }
    ]
  },  

  {
    label: 'Inventario',
    items: [
      { label: 'Inventario', routerLink: ['/inventario'] },
    ]
  },

    {
    label: 'Saldo de Caja',
    items: [
      { label: 'Saldo de Caja', routerLink: ['/saldocaja'] },
    ]
  },

    {
    label: 'Productos',
    items: [
      { label: 'Productos', routerLink: ['/productos'] },

    ]
  },

    {
    label: 'Servicios',
    items: [
      { label: 'Servicios', routerLink: ['/servicios'] },

    ]
  },


];

  constructor(private readonly auth$: AuthService) {}

  ngOnInit() 
  {        
      this.auth$.getUserName().subscribe(name => {        
        this.userName = name!;
        if(this.userName === null){
          this.isLogged= false;
        } else{
          this.isLogged= true;
        }        
      });        
  }

  logout(){
    this.auth$.signOut();
    this.isLogged= false;
    this.dropdownVisible = false;
  }

  toggleDropdown(){
    this.dropdownVisible = !this.dropdownVisible;
  }

  toggleSidebar() {
    this.sidebarVisible = !this.sidebarVisible;
  }
}
