import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpService } from '../http-service/http.service';
import { environment } from '../../../../environments/environment';

import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { Producto } from '../../interfaces/producto.interface';
import { CreateOrUpdateProducto } from '../../interfaces/CreateOrUpdateProducto.interface';

@Injectable({ providedIn: 'root' })
export class ProductoService {
  constructor(private readonly httpService: HttpService) {}

  public getListWithFilter(data: FieldFilter[]): Observable<Producto[]> {
    return this.httpService.doPost<FieldFilter[], Producto[]>(
      `${environment.endpoint_api_Producto}/list`,
      data
    );
  }

  public getList(): Observable<Producto[]> {
    return this.httpService.doGet<Producto[]>(
      `${environment.endpoint_api_Producto}`
    );
  }

  public getDesactivados(): Observable<Producto[]> {
    return this.httpService.doGet<Producto[]>(
      `${environment.endpoint_api_Producto}/desactivados`
    );
  }

  public create({ codigo, nombre }: CreateOrUpdateProducto): Observable<unknown> {
    return this.httpService.doPost<Partial<CreateOrUpdateProducto>, unknown>(
      `${environment.endpoint_api_Producto}`,
      { codigo, nombre }
    );
  }

  public update({ productoId, codigo, nombre }: CreateOrUpdateProducto): Observable<unknown> {
    return this.httpService.doPut<Partial<CreateOrUpdateProducto>, unknown>(
      `${environment.endpoint_api_Producto}`,
      { productoId, codigo, nombre }
    );
  }

  public delete(id: number): Observable<{ mensaje: string }> {
    return this.httpService.doDelete<{ mensaje: string }>(
      `${environment.endpoint_api_Producto}/${id}`
    );
  }

  public reactivar(id: number): Observable<{ mensaje: string }> {
    return this.httpService.doPut<unknown, { mensaje: string }>(
      `${environment.endpoint_api_Producto}/reactivar/${id}`,
      {}
    );
  }

  /**
   * Comprueba si existe un producto por código.
   * Implementación preferida: backend expone GET /exists/{code} que devuelve { existe: boolean }
   * Fallback: devuelve false inmediatamente si el código está vacío.
   */
  public existsByCode(code: string): Observable<boolean> {
    const c = (code || '').toString().trim();
    if (!c) {
      return of(false);
    }

    const url = `${environment.endpoint_api_Producto}/exists/${encodeURIComponent(c)}`;
    return this.httpService.doGet<{ existe: boolean }>(url).pipe(
      map(response => !!response?.existe)
    );
  }

  /**
   * Búsqueda por nombre o código usando endpoint list con filtros (igual que en ServicioService)
   */
  public buscarPorNombre(query: string): Observable<Producto[]> {
    const q = (query || '').trim();
    if (!q) {
      return this.getList();
    }
    const filters: FieldFilter[] = [
      { field: 'nombre', value: q },
      { field: 'codigo', value: q }
    ];
    return this.getListWithFilter(filters);
  }
}