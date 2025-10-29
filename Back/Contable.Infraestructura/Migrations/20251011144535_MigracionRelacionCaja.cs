using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class MigracionRelacionCaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Inventario_InventarioId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CajaId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3979));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3931));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 45, 35, 441, DateTimeKind.Utc).AddTicks(3932));

            migrationBuilder.CreateIndex(
                name: "IX_Factura_CajaId",
                schema: "dbo",
                table: "Factura",
                column: "CajaId");

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

            migrationBuilder.DropIndex(
                name: "IX_Factura_CajaId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "CajaId",
                schema: "dbo",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioId",
                schema: "dbo",
                table: "Factura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9660));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9859));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9911));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9889));

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Inventario_InventarioId",
                schema: "dbo",
                table: "Factura",
                column: "InventarioId",
                principalSchema: "dbo",
                principalTable: "Inventario",
                principalColumn: "InventarioId");
        }
    }
}
