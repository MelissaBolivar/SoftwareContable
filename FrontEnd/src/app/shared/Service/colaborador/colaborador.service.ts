import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { FieldFilter } from '../../interfaces/FieldFilter.interface';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Colaborador } from '../../interfaces/colaborador.interface';
import { CreateOrUpdateColaborador } from '../../interfaces/CreateOrUpdateColaborador.interface';

@Injectable()
export class ColaboradorService {
constructor(private readonly httpService: HttpService) { }

  public getListWithFilter(data: FieldFilter[]): Observable<Colaborador[]> {    
    return this.httpService.doPost<FieldFilter[],Colaborador[]>(
      `${environment.endpoint_api_Terceros}/list`,
      data
    );
  }

  public getList(): Observable<Colaborador[]> {    
    const idTipoTercero=3;   
    return this.httpService.doGet(
      `${environment.endpoint_api_Terceros}/byTipoTercero/${idTipoTercero}`,
    );
  }

  public create(createReservation: CreateOrUpdateColaborador): Observable<unknown> {
    return this.httpService.doPost<CreateOrUpdateColaborador,unknown>(
      `${environment.endpoint_api_Terceros}`,
      createReservation
    );
  }
  
  public update(createReservation: CreateOrUpdateColaborador): Observable<unknown> {
    return this.httpService.doPut<CreateOrUpdateColaborador,unknown>(
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



