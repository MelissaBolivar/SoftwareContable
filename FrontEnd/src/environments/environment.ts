import { api } from "./api.constants";
import { YARP_CEIBA_XM } from "./environment.constants";

export const environment = {
  production: false,

  // Endpoints generales
  endpoint_api_deposit: `${YARP_CEIBA_XM}${api.deposit}`,
  endpoint_api_user: `${YARP_CEIBA_XM}${api.user}`,
  endpoint_view_transaction: `${YARP_CEIBA_XM}${api.ViewTransaction}`,
  endpoint_api_MonetaryFund: `${YARP_CEIBA_XM}${api.MonetaryFund}`,
  endpoint_api_ExpenseType: `${YARP_CEIBA_XM}${api.ExpenseType}`,
  endpoint_api_TipoIdentificacion: `${YARP_CEIBA_XM}${api.TipoIdentificacion}`,

  // Endpoints usados por facturasventa.service.ts
  endpoint_api_Terceros: `${YARP_CEIBA_XM}${api.Terceros}`,
  endpoint_api_Factura: `${YARP_CEIBA_XM}${api.Factura}`,
  endpoint_api_Producto: `${YARP_CEIBA_XM}${api.Producto}`,
  endpoint_api_Servicio: `${YARP_CEIBA_XM}${api.Servicio}`,
  endpoint_api_TipoPago: `${YARP_CEIBA_XM}${api.TipoPago}`,
  endpoint_api_TipoFactura: `${YARP_CEIBA_XM}${api.TipoFactura}`,
  endpoint_api_Anticipo: `${YARP_CEIBA_XM}${api.Anticipo}`,

  // Firebase config
  firebaseConfig: {
    apiKey: "AIzaSyD8HUYxexZO1dM7iKAZ-K1qUzHOxrcVZLg",
    authDomain: "loguin-3ae79.firebaseapp.com",
    projectId: "loguin-3ae79",
    storageBucket: "loguin-3ae79.appspot.com",
    messagingSenderId: "763809996450",
    appId: "1:763809996450:web:56bbf83cae14ae87acc1fb",
    measurementId: "G-RZJ10SMTB3"
  }
};
