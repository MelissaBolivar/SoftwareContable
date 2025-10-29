using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Rol",
                columns: new[] { "RolId", "Activo", "DescripcionRol", "FechaRegistro", "NombreRol" },
                values: new object[,]
                {
                    { 1, false, "Administrador", new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9657), "Administrador" },
                    { 2, false, "Contable", new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9660), "Contable" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoDoc",
                columns: new[] { "TipoDocId", "Activo", "FechaRegistro", "Nombre" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9853), "Cédula de ciudadanía" },
                    { 2, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9855), "NIT" },
                    { 3, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9857), "Cédula de extranjería" },
                    { 4, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9859), "Pasaporte" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoFactura",
                columns: new[] { "TipoFacturaId", "Activo", "FechaRegistro", "Nombre" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9911), "Compra" },
                    { 2, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9913), "Venta" },
                    { 3, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9915), "Comprobante de caja" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoPago",
                columns: new[] { "TipoPagoId", "Activo", "FechaRegistro", "Nombre" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9938), "Crédito" },
                    { 2, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9941), "Contado" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoTercero",
                columns: new[] { "TipoTerceroId", "Activo", "FechaRegistro", "Nombre" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9886), "Proveedor" },
                    { 2, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9888), "Cliente" },
                    { 3, false, new DateTime(2025, 10, 11, 14, 28, 20, 759, DateTimeKind.Utc).AddTicks(9889), "Colaborador" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3);
        }
    }
}
