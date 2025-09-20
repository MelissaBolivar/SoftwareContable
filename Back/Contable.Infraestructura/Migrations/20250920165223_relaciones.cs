using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdRol",
                schema: "dbo",
                table: "Gastos",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdTipoPago",
                schema: "dbo",
                table: "Gastos",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Costos_IdProveedor",
                schema: "dbo",
                table: "Costos",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Costos_IdRol",
                schema: "dbo",
                table: "Costos",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Costos_IdTipoPago",
                schema: "dbo",
                table: "Costos",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdProveedor",
                schema: "dbo",
                table: "Compras",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdRol",
                schema: "dbo",
                table: "Compras",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdTipoPago",
                schema: "dbo",
                table: "Compras",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdRol",
                schema: "dbo",
                table: "Clientes",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Anticipos_IdRol",
                schema: "dbo",
                table: "Anticipos",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Anticipos_Rol_IdRol",
                schema: "dbo",
                table: "Anticipos",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Rol_IdRol",
                schema: "dbo",
                table: "Clientes",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Proveedores_IdProveedor",
                schema: "dbo",
                table: "Compras",
                column: "IdProveedor",
                principalSchema: "dbo",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Rol_IdRol",
                schema: "dbo",
                table: "Compras",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Compras",
                column: "IdTipoPago",
                principalSchema: "dbo",
                principalTable: "TipoDePago",
                principalColumn: "TipoPagoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Costos_Proveedores_IdProveedor",
                schema: "dbo",
                table: "Costos",
                column: "IdProveedor",
                principalSchema: "dbo",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costos_Rol_IdRol",
                schema: "dbo",
                table: "Costos",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Costos_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Costos",
                column: "IdTipoPago",
                principalSchema: "dbo",
                principalTable: "TipoDePago",
                principalColumn: "TipoPagoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Rol_IdRol",
                schema: "dbo",
                table: "Gastos",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Gastos",
                column: "IdTipoPago",
                principalSchema: "dbo",
                principalTable: "TipoDePago",
                principalColumn: "TipoPagoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anticipos_Rol_IdRol",
                schema: "dbo",
                table: "Anticipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Rol_IdRol",
                schema: "dbo",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Proveedores_IdProveedor",
                schema: "dbo",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Rol_IdRol",
                schema: "dbo",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Costos_Proveedores_IdProveedor",
                schema: "dbo",
                table: "Costos");

            migrationBuilder.DropForeignKey(
                name: "FK_Costos_Rol_IdRol",
                schema: "dbo",
                table: "Costos");

            migrationBuilder.DropForeignKey(
                name: "FK_Costos_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Costos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Rol_IdRol",
                schema: "dbo",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_TipoDePago_IdTipoPago",
                schema: "dbo",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_IdRol",
                schema: "dbo",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_IdTipoPago",
                schema: "dbo",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Costos_IdProveedor",
                schema: "dbo",
                table: "Costos");

            migrationBuilder.DropIndex(
                name: "IX_Costos_IdRol",
                schema: "dbo",
                table: "Costos");

            migrationBuilder.DropIndex(
                name: "IX_Costos_IdTipoPago",
                schema: "dbo",
                table: "Costos");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdProveedor",
                schema: "dbo",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdRol",
                schema: "dbo",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdTipoPago",
                schema: "dbo",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdRol",
                schema: "dbo",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Anticipos_IdRol",
                schema: "dbo",
                table: "Anticipos");
        }
    }
}
