import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
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
export class HeaderComponent implements OnInit {
  sidebarVisible = false;
  dropdownVisible = false;
  userName = '';
  isLogged = true;

  menuItems: MenuItem[] = [];

  constructor(
    private readonly auth$: AuthService,
    private readonly router: Router
  ) {}

  ngOnInit() {
    this.auth$.getUserName().subscribe(name => {
      this.userName = name ?? '';
      this.isLogged = !!this.userName;
    });

    // ✅ Configuración del menú con navegación directa
    this.menuItems = [
      {
        label: 'Terceros',
        items: [
          { label: 'Proveedores', routerLink: ['/Proveedores'], command: () => this.navigateTo('/Proveedores') },
          { label: 'Clientes', routerLink: ['/Clientes'], command: () => this.navigateTo('/Clientes') },
          { label: 'Colaboradores', routerLink: ['/Colaboradores'], command: () => this.navigateTo('/Colaboradores') }
        ]
      },
      {
        label: 'Productos',
        items: [
          { label: 'Productos', routerLink: ['/productos'], command: () => this.navigateTo('/productos') },
        ]
      },
      {
        label: 'Servicios',
        items: [
          { label: 'Servicios', routerLink: ['/servicios'], command: () => this.navigateTo('/servicios') },
        ]
      },
      {
        label: 'Facturas',
        items: [
          { label: 'Facturas de Compra', routerLink: ['/facturascompra'], command: () => this.navigateTo('/facturascompra') },
          { label: 'Facturas de Venta', routerLink: ['/facturasventa'], command: () => this.navigateTo('/facturasventa') },       
          { label: 'Comprobante de Caja', routerLink: ['/comprobantecaja'], command: () => this.navigateTo('/comprobantecaja') }
        ]
      },
      {
        label: 'Inventario',
        items: [
          { label: 'Inventario', routerLink: ['/inventario'], command: () => this.navigateTo('/inventario') },
        ]
      },
      {
        label: 'Saldo de Caja',
        items: [
          { label: 'Saldo de Caja', routerLink: ['/caja'], command: () => this.navigateTo('/caja') },
        ]
      },
    ];
  }

  /** 🔹 Cerrar sesión */
  logout() {
    this.auth$.signOut();
    this.isLogged = false;
    this.dropdownVisible = false;
  }

  /** 🔹 Alternar dropdown usuario */
  toggleDropdown() {
    this.dropdownVisible = !this.dropdownVisible;
  }

  /** 🔹 Mostrar/Ocultar sidebar */
  toggleSidebar() {
    this.sidebarVisible = !this.sidebarVisible;
  }

  /** 🔹 Ir al Home */
  goHome() {
    this.sidebarVisible = false;
    this.router.navigate(['/home']);
  }

  /** 🔹 Navegación directa al módulo y cierre de sidebar */
  private navigateTo(route: string) {
    this.sidebarVisible = false;
    this.router.navigate([route]).then(() => {
      // Forzamos el refresco visual del módulo
      window.dispatchEvent(new Event('resize'));
    });
  }
}
