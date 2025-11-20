export interface Inventario{

inventarioId: number;
producto: string; 
unidades: number; 
precioCompra: number; 
precioVenta: number; 
nombre: string;
codigo: string;
}

export interface Caja{
    fechaRegistro: string;
    concepto: string;
    saldo: number; 
}

