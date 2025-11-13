export interface CreateOrUpdateCliente{
    TerceroId?:number | null;
    TipoDocId: string;
    NumeroDoc: string;
    RazonSocialTercero: string;
    DireccionTercero: string;
    TelefonoTercero: string;
    CorreoElectronicoTercero: string;
    TipoTerceroId:number;
}