import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { CreateOrUpdateCliente } from '../../interfaces/CreateOrUpdateCliente.interface';
import { Cliente } from '../../interfaces/cliente.interface';

@Injectable()
export class ClienteService {
  private readonly base = environment.endpoint_api_Terceros;

  constructor(private readonly httpService: HttpService) { }

  public getListWithFilter(data: FieldFilter[]): Observable<Cliente[]> {
    return this.httpService.doPost(
      `${this.base}/list`,
      data
    );
  }

  public getList(): Observable<Cliente[]> {
    const idTipoTercero = 2;
    return this.httpService.doGet(
      `${this.base}/byTipoTercero/${idTipoTercero}`
    );
  }

  public getListByActivo(activo: boolean): Observable<Cliente[]> {
    return this.httpService.doGet(
      `${this.base}/byActivo?activo=${activo}`
    );
  }

  public getById(id: number): Observable<Cliente> {
    return this.httpService.doGet(`${this.base}/${id}`);
  }

  public create(payload: CreateOrUpdateCliente): Observable<unknown> {
    return this.httpService.doPost(
      `${this.base}`,
      payload
    );
  }

  public update(payload: CreateOrUpdateCliente): Observable<unknown> {
    return this.httpService.doPut(
      `${this.base}`,
      payload
    );
  }

  public delete(id: number): Observable<unknown> {
    return this.httpService.doDelete(`${this.base}/${id}`);
  }

  // Soft deactivate/reactivate using PUT to match backend verbs
  public deactivate(id: number): Observable<unknown> {
    return this.httpService.doPut(`${this.base}/deactivate/${id}`, null);
  }

  public reactivate(id: number): Observable<unknown> {
    return this.httpService.doPut(`${this.base}/reactivate/${id}`, null);
  }

  // Fallback: actualizar campo Activo vía update parcial
  public setActivo(id: number, activo: boolean): Observable<unknown> {
    const payload = { TerceroId: id, Activo: activo };
    return this.httpService.doPut(`${this.base}`, payload);
  }
}