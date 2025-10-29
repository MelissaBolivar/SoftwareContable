using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Migracionsieteh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "PorcentajeAnticipo" },
                values: new object[] { new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6977), 0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                columns: new[] { "FechaRegistro", "PorcentajeAnticipo" },
                values: new object[] { new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6979), 10 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Anticipo",
                columns: new[] { "AnticipoId", "Activo", "FechaRegistro", "PorcentajeAnticipo" },
                values: new object[] { 3, false, new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6980), 30 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6715));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6889));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6891));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6892));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6935));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6938));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6959));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6960));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 17, 0, 58, 27, 706, DateTimeKind.Utc).AddTicks(6916));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "PorcentajeAnticipo" },
                values: new object[] { new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4265), 10 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Anticipo",
                keyColumn: "AnticipoId",
                keyValue: 2,
                columns: new[] { "FechaRegistro", "PorcentajeAnticipo" },
                values: new object[] { new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4267), 30 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(3923));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rol",
                keyColumn: "RolId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoDoc",
                keyColumn: "TipoDocId",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoFactura",
                keyColumn: "TipoFacturaId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4237));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoPago",
                keyColumn: "TipoPagoId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4189));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4191));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TipoTercero",
                keyColumn: "TipoTerceroId",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2025, 10, 16, 23, 28, 41, 190, DateTimeKind.Utc).AddTicks(4192));
        }
    }
}
