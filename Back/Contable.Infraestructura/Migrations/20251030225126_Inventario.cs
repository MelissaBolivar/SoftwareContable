using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Inventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnidadesInventario",
                schema: "dbo",
                table: "Inventario",
                newName: "Unidades");

            migrationBuilder.RenameColumn(
                name: "PrecioVentaInventario",
                schema: "dbo",
                table: "Inventario",
                newName: "Producto");

            migrationBuilder.RenameColumn(
                name: "PrecioCompraInventario",
                schema: "dbo",
                table: "Inventario",
                newName: "PrecioVenta");

            migrationBuilder.AddColumn<int>(
                name: "PrecioCompra",
                schema: "dbo",
                table: "Inventario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(4914));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5146));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5315));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 22, 51, 25, 659, DateTimeKind.Utc).AddTicks(5195));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                schema: "dbo",
                table: "Inventario");

            migrationBuilder.RenameColumn(
                name: "Unidades",
                schema: "dbo",
                table: "Inventario",
                newName: "UnidadesInventario");

            migrationBuilder.RenameColumn(
                name: "Producto",
                schema: "dbo",
                table: "Inventario",
                newName: "PrecioVentaInventario");

            migrationBuilder.RenameColumn(
                name: "PrecioVenta",
                schema: "dbo",
                table: "Inventario",
                newName: "PrecioCompraInventario");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(689));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(691));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(693));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(259));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(573));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(579));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(641));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(643));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(645));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(668));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(614));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 22, 4, 11, 14, 832, DateTimeKind.Utc).AddTicks(616));
        }
    }
}
