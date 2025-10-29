using Contable.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class DetalleProducto
{
    [Key]
    public int DetalleProductoId { get; set; }

    public int FacturaId { get; set; }
    public Factura Factura { get; set; }

    public int ProductoId { get; set; }
    public Producto Producto { get; set; }

    public int Unidades { get; set; }
    public decimal PrecioUnitario { get; set; }
}