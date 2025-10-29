public class FacturaDTO
{
    public int FacturaId { get; set; }
    public DateTime Fecha { get; set; }
    public int NumeroFactura { get; set; }
    public string Observaciones { get; set; }
    public int Total { get; set; }
    public int TipoPagoId { get; set; }
    public int TipoFacturaId { get; set; }
    public int AnticipoId { get; set; }
    public int TerceroId { get; set; }

    public List<DetalleProductoDTO> DetalleProducto { get; set; }
    public List<DetalleServicioDTO> DetalleServicio { get; set; }
}

public class DetalleProductoDTO
{
    public int DetalleProductoId { get; set; }
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; }
    public int Unidades { get; set; }
    public decimal PrecioUnitario { get; set; }
}

public class DetalleServicioDTO
{
    public int DetalleServicioId { get; set; }
    public int ServicioId { get; set; }
    public string NombreServicio { get; set; }
    public int Unidades { get; set; }
    public decimal PrecioUnitario { get; set; }
}

