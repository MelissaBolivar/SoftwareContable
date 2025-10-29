import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { HttpService } from '../http-service/http.service';
import { environment } from '../../../../environments/environment';

import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { Servicio } from '../../interfaces/servicio.interface';
import { CreateOrUpdateServicio } from '../../interfaces/CreateOrUpdateServicio.interface';


@Injectable({ providedIn: 'root' })
export class ServicioService {
  constructor(private readonly httpService: HttpService) {}

  public getListWithFilter(data: FieldFilter[]): Observable<Servicio[]> {
    return this.httpService.doPost<FieldFilter[], Servicio[]>(
      `${environment.endpoint_api_Servicio}/list`,
      data
    );
  }

  public getList(): Observable<Servicio[]> {
    return this.httpService.doGet<Servicio[]>(
      `${environment.endpoint_api_Servicio}`
    );
  }

  public getDesactivados(): Observable<Servicio[]> {
    return this.httpService.doGet<Servicio[]>(
      `${environment.endpoint_api_Servicio}/desactivados`
    );
  }

  public create({ codigo, nombre }: CreateOrUpdateServicio): Observable<unknown> {
    return this.httpService.doPost<Partial<CreateOrUpdateServicio>, unknown>(
      `${environment.endpoint_api_Servicio}`,
      { codigo, nombre }
    );
  }

  public update({ servicioId, codigo, nombre }: CreateOrUpdateServicio): Observable<unknown> {
    return this.httpService.doPut<Partial<CreateOrUpdateServicio>, unknown>(
      `${environment.endpoint_api_Servicio}`,
      { servicioId, codigo, nombre }
    );
  }

  public delete(id: number): Observable<{ mensaje: string }> {
    return this.httpService.doDelete<{ mensaje: string }>(
      `${environment.endpoint_api_Servicio}/${id}`
    );
  }

  public reactivar(id: number): Observable<{ mensaje: string }> {
    return this.httpService.doPut<unknown, { mensaje: string }>(
      `${environment.endpoint_api_Servicio}/reactivar/${id}`,
      {}
    );
  }

  // Busca por nombre o código usando el endpoint de list con filtros
  public buscarPorNombre(query: string): Observable<Servicio[]> {
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
