import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../http-service/http.service';
import { environment } from '../../../../environments/environment';

import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { FacturasCompra } from '../../interfaces/facturascompra.interface';
import { CreateOrUpdateFacturasCompra } from '../../interfaces/CreateOrUpdateFacturasCompra.interface';

@Injectable()
export class FacturasCompraService {
  constructor(private readonly httpService: HttpService) {}

  // ─────────────────────────────────────────────────────────────
  // 🔹 Operaciones CRUD sobre Facturas
  // ─────────────────────────────────────────────────────────────

  /**
   * Obtiene la lista completa de facturas.
   */
    public getList(): Observable<FacturasCompra[]> {    
      const idTipoFactura=1;   
      return this.httpService.doGet(
        `${environment.endpoint_api_Factura}/byTipoFactura/${idTipoFactura}`,
      );
    }

  /**
   * Obtiene la lista de facturas aplicando filtros personalizados.
   * @param data Filtros de búsqueda
   */
  public getListWithFilter(data: FieldFilter[]): Observable<FacturasCompra[]> {
    return this.httpService.doPost<FieldFilter[], FacturasCompra[]>(
      `${environment.endpoint_api_Factura}/list`,
      data
    );
  }

  /**
   * Crea una nueva factura.
   * @param createFactura Datos de la factura a crear
   */
  public create(createFactura: CreateOrUpdateFacturasCompra): Observable<unknown> {
    return this.httpService.doPost<CreateOrUpdateFacturasCompra, unknown>(
      `${environment.endpoint_api_Factura}`,
      createFactura
    );
  }

  /**
   * Actualiza una factura existente.
   * @param updateFactura Datos actualizados de la factura
   */
  public update(updateFactura: CreateOrUpdateFacturasCompra): Observable<unknown> {
    return this.httpService.doPut<CreateOrUpdateFacturasCompra, unknown>(
      `${environment.endpoint_api_Factura}`,
      updateFactura
    );
  }

  /**
   * Elimina una factura por su ID.
   * @param id Identificador de la factura
   */
  public delete(id: number): Observable<unknown> {
    return this.httpService.doDelete<unknown>(
      `${environment.endpoint_api_Factura}/${id}`
    );
  }

  // ─────────────────────────────────────────────────────────────
  // 🔹 Métodos auxiliares para cargar listas relacionadas
  // ─────────────────────────────────────────────────────────────

  /**
   * Obtiene la lista de clientes registrados (razón social).
   */
  public getTerceros(): Observable<any[]> {
    return this.httpService.doGet(`${environment.endpoint_api_Terceros}`);
  }

  /**
   * Obtiene la lista de productos disponibles.
   */
  public getProducto(): Observable<any[]> {
    return this.httpService.doGet(`${environment.endpoint_api_Producto}`);
  }

  /**
   * Obtiene la lista de servicios disponibles.
   */
  public getServicio(): Observable<any[]> {
    return this.httpService.doGet(`${environment.endpoint_api_Servicio}`);
  }

  /**
   * Obtiene los tipos de pago disponibles.
   */
  public getTipoPago(): Observable<any[]> {
    return this.httpService.doGet(`${environment.endpoint_api_TipoPago}`);
  }

  /**
   * Obtiene los tipos de factura disponibles.
   */
  public getTipoFactura(): Observable<any[]> {
    return this.httpService.doGet(`${environment.endpoint_api_TipoFactura}`);
  }

  /**
   * Obtiene la lista de anticipos registrados.
   */
  public getAnticipo(): Observable<any[]> {
    return this.httpService.doGet(`${environment.endpoint_api_Anticipo}`);
  }
}
