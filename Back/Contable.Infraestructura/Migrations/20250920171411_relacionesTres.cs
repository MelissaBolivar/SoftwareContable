using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class relacionesTres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientesId",
                schema: "dbo",
                table: "Anticipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                schema: "dbo",
                table: "Anticipos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdAnticipo",
                schema: "dbo",
                table: "Ventas",
                column: "IdAnticipo");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                schema: "dbo",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdRol",
                schema: "dbo",
                table: "Ventas",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdTipoPago",
                schema: "dbo",
                table: "Ventas",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Anticipos_ClientesId",
                schema: "dbo",
                table: "Anticipos",
                column: "ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anticipos_Clientes_ClientesId",
                schema: "dbo",
                table: "Anticipos",
                column: "ClientesId",
                principalSchema: "dbo",
                principalTable: "Clientes",
                principalColumn: "ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Anticipos_IdAnticipo",
                schema: "dbo",
                table: "Ventas",
                column: "IdAnticipo",
                principalSchema: "dbo",
                principalTable: "Anticipos",
                principalColumn: "AnticiposId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_IdCliente",
                schema: "dbo",
                table: "Ventas",
                column: "IdCliente",
                principalSchema: "dbo",
                principalTable: "Clientes",
                principalColumn: "ClientesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Rol_IdRol",
                schema: "dbo",
                table: "Ventas",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Ventas",
                column: "IdTipoPago",
                principalSchema: "dbo",
                principalTable: "TipoDePago",
                principalColumn: "TipoPagoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anticipos_Clientes_ClientesId",
                schema: "dbo",
                table: "Anticipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Anticipos_IdAnticipo",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_IdCliente",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Rol_IdRol",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdAnticipo",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdCliente",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdRol",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdTipoPago",
                schema: "dbo",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Anticipos_ClientesId",
                schema: "dbo",
                table: "Anticipos");

            migrationBuilder.DropColumn(
                name: "ClientesId",
                schema: "dbo",
                table: "Anticipos");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                schema: "dbo",
                table: "Anticipos");
        }
    }
}
