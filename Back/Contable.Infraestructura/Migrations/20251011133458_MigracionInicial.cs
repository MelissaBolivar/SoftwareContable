using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Anticipo",
                schema: "dbo",
                columns: table => new
                {
                    AnticipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorcentajeAnticipo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anticipo", x => x.AnticipoId);
                });

            migrationBuilder.CreateTable(
                name: "Caja",
                schema: "dbo",
                columns: table => new
                {
                    CajaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.CajaId);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                schema: "dbo",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadesInventario = table.Column<int>(type: "int", nullable: false),
                    PrecioVentaInventario = table.Column<int>(type: "int", nullable: false),
                    PrecioCompraInventario = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.InventarioId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "dbo",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "dbo",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                schema: "dbo",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDoc",
                schema: "dbo",
                columns: table => new
                {
                    TipoDocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDoc", x => x.TipoDocId);
                });

            migrationBuilder.CreateTable(
                name: "TipoFactura",
                schema: "dbo",
                columns: table => new
                {
                    TipoFacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFactura", x => x.TipoFacturaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPago",
                schema: "dbo",
                columns: table => new
                {
                    TipoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPago", x => x.TipoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoTercero",
                schema: "dbo",
                columns: table => new
                {
                    TipoTerceroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTercero", x => x.TipoTerceroId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumentoUsuario = table.Column<int>(type: "int", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronicoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserGoogle = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "dbo",
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoDoc_TipoDocId",
                        column: x => x.TipoDocId,
                        principalSchema: "dbo",
                        principalTable: "TipoDoc",
                        principalColumn: "TipoDocId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tercero",
                schema: "dbo",
                columns: table => new
                {
                    TerceroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocId = table.Column<int>(type: "int", nullable: false),
                    TipoTerceroId = table.Column<int>(type: "int", nullable: false),
                    NumeroDoc = table.Column<int>(type: "int", nullable: false),
                    RazonSocialTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronicoTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.TerceroId);
                    table.ForeignKey(
                        name: "FK_Tercero_TipoDoc_TipoDocId",
                        column: x => x.TipoDocId,
                        principalSchema: "dbo",
                        principalTable: "TipoDoc",
                        principalColumn: "TipoDocId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tercero_TipoTercero_TipoTerceroId",
                        column: x => x.TipoTerceroId,
                        principalSchema: "dbo",
                        principalTable: "TipoTercero",
                        principalColumn: "TipoTerceroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                schema: "dbo",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerceroId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    TipoPagoId = table.Column<int>(type: "int", nullable: false),
                    TipoFacturaId = table.Column<int>(type: "int", nullable: false),
                    AnticipoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFactura = table.Column<int>(type: "int", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Factura_Anticipo_AnticipoId",
                        column: x => x.AnticipoId,
                        principalSchema: "dbo",
                        principalTable: "Anticipo",
                        principalColumn: "AnticipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalSchema: "dbo",
                        principalTable: "Inventario",
                        principalColumn: "InventarioId");
                    table.ForeignKey(
                        name: "FK_Factura_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "dbo",
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalSchema: "dbo",
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalSchema: "dbo",
                        principalTable: "Tercero",
                        principalColumn: "TerceroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_TipoFactura_TipoFacturaId",
                        column: x => x.TipoFacturaId,
                        principalSchema: "dbo",
                        principalTable: "TipoFactura",
                        principalColumn: "TipoFacturaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_TipoPago_TipoPagoId",
                        column: x => x.TipoPagoId,
                        principalSchema: "dbo",
                        principalTable: "TipoPago",
                        principalColumn: "TipoPagoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_AnticipoId",
                schema: "dbo",
                table: "Factura",
                column: "AnticipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_InventarioId",
                schema: "dbo",
                table: "Factura",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ProductoId",
                schema: "dbo",
                table: "Factura",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ServicioId",
                schema: "dbo",
                table: "Factura",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_TerceroId",
                schema: "dbo",
                table: "Factura",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_TipoFacturaId",
                schema: "dbo",
                table: "Factura",
                column: "TipoFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_TipoPagoId",
                schema: "dbo",
                table: "Factura",
                column: "TipoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_TipoDocId",
                schema: "dbo",
                table: "Tercero",
                column: "TipoDocId");

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_TipoTerceroId",
                schema: "dbo",
                table: "Tercero",
                column: "TipoTerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                schema: "dbo",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoDocId",
                schema: "dbo",
                table: "Usuario",
                column: "TipoDocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caja",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Factura",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Anticipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Inventario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Servicio",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tercero",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoFactura",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoPago",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoDoc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoTercero",
                schema: "dbo");
        }
    }
}
