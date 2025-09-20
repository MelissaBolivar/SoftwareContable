using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class Iniciald : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdProveedor",
                schema: "dbo",
                table: "Gastos",
                column: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Proveedores_IdProveedor",
                schema: "dbo",
                table: "Gastos",
                column: "IdProveedor",
                principalSchema: "dbo",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Proveedores_IdProveedor",
                schema: "dbo",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_IdProveedor",
                schema: "dbo",
                table: "Gastos");
        }
    }
}
