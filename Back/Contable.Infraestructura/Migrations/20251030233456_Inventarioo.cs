using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Inventarioo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Caja_CajaId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Inventario_InventarioId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9116));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9117));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9119));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9017));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9097));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 34, 55, 835, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Caja_CajaId",
                schema: "dbo",
                table: "Factura",
                column: "CajaId",
                principalSchema: "dbo",
                principalTable: "Caja",
                principalColumn: "CajaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Inventario_InventarioId",
                schema: "dbo",
                table: "Factura",
                column: "InventarioId",
                principalSchema: "dbo",
                principalTable: "Inventario",
                principalColumn: "InventarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Caja_CajaId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Inventario_InventarioId",
                schema: "dbo",
                table: "Factura");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Caja_CajaId",
                schema: "dbo",
                table: "Factura",
                column: "CajaId",
                principalSchema: "dbo",
                principalTable: "Caja",
                principalColumn: "CajaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Inventario_InventarioId",
                schema: "dbo",
                table: "Factura",
                column: "InventarioId",
                principalSchema: "dbo",
                principalTable: "Inventario",
                principalColumn: "InventarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
