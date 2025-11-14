export interface Proveedor{
    id:string;
    userId: string;
    userName: string;
    expenseTypeId: string;
    expenseTypeName: string;
    month: string;
    year: string;
    amount: string;

terceroId: string;
tipoDocId: string;
tipoDeTerceroId: string;
numeroDoc: string;
razonSocialTercero: string;
direccionTercero?: string; 
telefonoTercero: string; 
correoElectronicoTercero: string; 
fechaRegistro: string; 
estado?: boolean;
ventas: string; 
tipoDeIdentificacion: string;
activo: boolean;
}

