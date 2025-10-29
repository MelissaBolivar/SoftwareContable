using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Modulofacturasconproductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Producto_ProductoId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Servicio_ServicioId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Precio",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Unidades",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DetalleProducto",
                schema: "dbo",
                columns: table => new
                {
                    DetalleProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.DetalleProductoId);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalSchema: "dbo",
                        principalTable: "Factura",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "dbo",
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleServicio",
                schema: "dbo",
                columns: table => new
                {
                    DetalleServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleServicio", x => x.DetalleServicioId);
                    table.ForeignKey(
                        name: "FK_DetalleServicio_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalSchema: "dbo",
                        principalTable: "Factura",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleServicio_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalSchema: "dbo",
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8617));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8620));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 2, 24, 57, 48, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_FacturaId",
                schema: "dbo",
                table: "DetalleProducto",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_ProductoId",
                schema: "dbo",
                table: "DetalleProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicio_FacturaId",
                schema: "dbo",
                table: "DetalleServicio",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicio_ServicioId",
                schema: "dbo",
                table: "DetalleServicio",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Producto_ProductoId",
                schema: "dbo",
                table: "Factura",
                column: "ProductoId",
                principalSchema: "dbo",
                principalTable: "Producto",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Servicio_ServicioId",
                schema: "dbo",
                table: "Factura",
                column: "ServicioId",
                principalSchema: "dbo",
                principalTable: "Servicio",
                principalColumn: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Producto_ProductoId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Servicio_ServicioId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "DetalleProducto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DetalleServicio",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Precio",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Unidades",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8458));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(7635));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8084));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8087));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8089));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8217));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8218));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8280));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 20, 1, 59, 54, 472, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Producto_ProductoId",
                schema: "dbo",
                table: "Factura",
                column: "ProductoId",
                principalSchema: "dbo",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Servicio_ServicioId",
                schema: "dbo",
                table: "Factura",
                column: "ServicioId",
                principalSchema: "dbo",
                principalTable: "Servicio",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
