import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Inventario } from '../../interfaces/inventario.interface';
import { CreateOrUpdateInventario } from '../../interfaces/CreateOrUpdateInventario.interface';

@Injectable()
export class InventarioService {
constructor(private readonly httpService: HttpService) { }

  public getListWithFilter(data: FieldFilter[]): Observable<Inventario[]> {    
    return this.httpService.doPost<FieldFilter[],Inventario[]>(
      `${environment.endpoint_api_Terceros}/list`,
      data
    );
  }

  public getList(): Observable<Inventario[]> {  
    const idTipoTercero=1;     
    return this.httpService.doGet(
      `${environment.endpoint_api_Inventario}`,
    );
  }

  public create(createReservation: CreateOrUpdateInventario): Observable<unknown> {
    return this.httpService.doPost<CreateOrUpdateInventario,unknown>(
      `${environment.endpoint_api_Terceros}`,
      createReservation
    );
  }
  
  public update(createReservation: CreateOrUpdateInventario): Observable<unknown> {
    return this.httpService.doPut<CreateOrUpdateInventario,unknown>(
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
