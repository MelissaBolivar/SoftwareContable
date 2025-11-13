import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Colaborador } from '../../interfaces/colaborador.interface';
import { CreateOrUpdateColaborador } from '../../interfaces/CreateOrUpdateColaborador.interface';

@Injectable({ providedIn: 'root' })
export class ColaboradorService {
  private base = environment.endpoint_api_Terceros;

  constructor(private readonly httpService: HttpService) { }

  public getListWithFilter(data: FieldFilter[]): Observable<Colaborador[]> {
    return this.httpService.doPost<FieldFilter[],Colaborador[]>(
      `${this.base}/list`,
      data
    );
  }

  public getList(): Observable<Colaborador[]> {
    const idTipoTercero = 3;
    return this.httpService.doGet(
      `${this.base}/byTipoTercero/${idTipoTercero}`,
    );
  }

  public create(createReservation: CreateOrUpdateColaborador): Observable<unknown> {
    return this.httpService.doPost<CreateOrUpdateColaborador,unknown>(
      `${this.base}`,
      createReservation
    );
  }

  public update(createReservation: CreateOrUpdateColaborador): Observable<unknown> {
    return this.httpService.doPut<CreateOrUpdateColaborador,unknown>(
      `${this.base}`,
      createReservation
    );
  }

  public delete(id: number): Observable<unknown> {
    return this.httpService.doDelete<unknown>(
      `${this.base}/${id}`
    );
  }

  // Explicit deactivate endpoint (uses the backend's flexible routes: POST/PUT/PATCH accepted)
  public deactivate(id: number): Observable<unknown> {
    return this.httpService.doPost<unknown, unknown>(`${this.base}/deactivate/${id}`, {});
  }

  // Explicit reactivate endpoint
  public reactivate(id: number): Observable<unknown> {
    return this.httpService.doPost<unknown, unknown>(`${this.base}/reactivate/${id}`, {});
  }

  // Optional generic activate if backend exposes it (kept for compatibility)
  public activate(id: number): Observable<unknown> {
    return this.httpService.doPut<unknown, unknown>(`${this.base}/reactivate/${id}`, {});
  }

  // Obtiene la lista de tipos de documento desde el endpoint específico (si existe)
  // Si tu environment tiene otra ruta para tipos, ajusta environment.endpoint_api_TipoIdentificacion
  public getTiposDocumento(): Observable<{ TipoDocId: number; Nombre: string }[]> {
    const tiposEndpoint = environment.endpoint_api_TipoIdentificacion ?? `${this.base}/tipos-documento`;
    return this.httpService.doGet(tiposEndpoint);
  }
}