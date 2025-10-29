import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'home',
    loadComponent: () => import('./feature/home/home.component').then(m => m.HomeComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'Proveedores',
    loadComponent: () => import('./feature/proveedores/proveedores.component').then(m => m.ProveedoresComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'Clientes',
    loadComponent: () => import('./feature/clientes/clientes.component').then(m => m.ClientesComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'Colaboradores',
    loadComponent: () => import('./feature/colaboradores/colaboradores.component').then(m => m.ColaboradoresComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'facturasventa',
    loadComponent: () => import('./feature/facturasventa/facturasventa.component').then(m => m.FacturasVentaComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'facturascompra',
    loadComponent: () => import('./feature/facturascompra/facturascompra.component').then(m => m.FacturasCompraComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'productos',
    loadComponent: () => import('./feature/producto/producto.component').then(m => m.ProductoComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'servicios',
    loadComponent: () => import('./feature/servicio/servicio.component').then(m => m.ServicioComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    loadComponent: () => import('./core/component/login/login.component').then(m => m.LoginComponent)
  },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home' }
];