export interface Cliente {
  id: string;
  terceroId: string;
  tipoDocId?: string | number;
  tipoDeTerceroId?: string;
  tipoDeIdentificacion?: string;

  userId?: string;
  userName?: string;

  numeroDoc?: string;
  razonSocialTercero?: string;
  direccionTercero?: string;
  telefonoTercero?: string;
  correoElectronicoTercero?: string;

  month?: string;
  year?: string;
  amount?: string;
  ventas?: string;

  fechaRegistro?: string;
  estado?: string;

  /** Normalización del estado activo para uso interno: true|false cuando esté disponible */
  Activo?: boolean;
  /** Posible forma alternativa que algunas APIs usan */
  activo?: boolean;
  /** Otra variante que puede venir desde el backend */
  isActive?: boolean;
}