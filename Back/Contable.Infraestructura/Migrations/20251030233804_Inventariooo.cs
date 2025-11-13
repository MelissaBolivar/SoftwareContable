using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Inventariooo : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Factura_CajaId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_InventarioId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "CajaId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6211));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6213));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 30, 23, 38, 4, 243, DateTimeKind.Utc).AddTicks(6214));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CajaId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Factura_CajaId",
                schema: "dbo",
                table: "Factura",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_InventarioId",
                schema: "dbo",
                table: "Factura",
                column: "InventarioId");

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
    }
}
