using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class CampoTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                schema: "dbo",
                table: "Factura");

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
        }
    }
}
