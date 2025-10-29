import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Proveedor } from '../../interfaces/proveedor.interface';
import { CreateOrUpdateProveedor } from '../../interfaces/CreateOrUpdateProveedor.interface';

@Injectable()
export class ProveedorService {
constructor(private readonly httpService: HttpService) { }

  public getListWithFilter(data: FieldFilter[]): Observable<Proveedor[]> {    
    return this.httpService.doPost<FieldFilter[],Proveedor[]>(
      `${environment.endpoint_api_Terceros}/list`,
      data
    );
  }

  public getList(): Observable<Proveedor[]> {  
    const idTipoTercero=1;     
    return this.httpService.doGet(
      `${environment.endpoint_api_Terceros}/byTipoTercero/${idTipoTercero}`,
    );
  }

  public create(createReservation: CreateOrUpdateProveedor): Observable<unknown> {
    return this.httpService.doPost<CreateOrUpdateProveedor,unknown>(
      `${environment.endpoint_api_Terceros}`,
      createReservation
    );
  }
  
  public update(createReservation: CreateOrUpdateProveedor): Observable<unknown> {
    return this.httpService.doPut<CreateOrUpdateProveedor,unknown>(
      `${environment.endpoint_api_Terceros}`,
      createReservation
    );
  }

  public delete(id: number): Observable<unknown> {
  return this.httpService.doDelete<unknown>(
    `${environment.endpoint_api_Terceros}/${id}`
  );
}

}
