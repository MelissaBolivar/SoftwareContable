using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contable.Infrastructure.Migrations
{
    public partial class relacionesDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdTipoIdentificacion",
                schema: "dbo",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                schema: "dbo",
                table: "TipoDeIdentificacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                schema: "dbo",
                table: "TipodeDisponible",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeIdentificacionTipoIdentificacionId",
                schema: "dbo",
                table: "Proveedores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                schema: "dbo",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                schema: "dbo",
                table: "Usuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoIdentificacion",
                schema: "dbo",
                table: "Usuario",
                column: "IdTipoIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeIdentificacion_RolId",
                schema: "dbo",
                table: "TipoDeIdentificacion",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_TipodeDisponible_RolId",
                schema: "dbo",
                table: "TipodeDisponible",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Tesoreria_IdRol",
                schema: "dbo",
                table: "Tesoreria",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Tesoreria_IdTipoDisponible",
                schema: "dbo",
                table: "Tesoreria",
                column: "IdTipoDisponible");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TipoDeIdentificacionTipoIdentificacionId",
                schema: "dbo",
                table: "Proveedores",
                column: "TipoDeIdentificacionTipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_RolId",
                schema: "dbo",
                table: "Item",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdItem",
                schema: "dbo",
                table: "Inventario",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdRol",
                schema: "dbo",
                table: "Inventario",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Item_IdItem",
                schema: "dbo",
                table: "Inventario",
                column: "IdItem",
                principalSchema: "dbo",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Rol_IdRol",
                schema: "dbo",
                table: "Inventario",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Rol_RolId",
                schema: "dbo",
                table: "Item",
                column: "RolId",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_TipoDeIdentificacion_TipoDeIdentificacionTipoIdentificacionId",
                schema: "dbo",
                table: "Proveedores",
                column: "TipoDeIdentificacionTipoIdentificacionId",
                principalSchema: "dbo",
                principalTable: "TipoDeIdentificacion",
                principalColumn: "TipoIdentificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tesoreria_Rol_IdRol",
                schema: "dbo",
                table: "Tesoreria",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tesoreria_TipodeDisponible_IdTipoDisponible",
                schema: "dbo",
                table: "Tesoreria",
                column: "IdTipoDisponible",
                principalSchema: "dbo",
                principalTable: "TipodeDisponible",
                principalColumn: "TipoDisponibleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipodeDisponible_Rol_RolId",
                schema: "dbo",
                table: "TipodeDisponible",
                column: "RolId",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeIdentificacion_Rol_RolId",
                schema: "dbo",
                table: "TipoDeIdentificacion",
                column: "RolId",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                schema: "dbo",
                table: "Usuario",
                column: "IdRol",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoDeIdentificacion_IdTipoIdentificacion",
                schema: "dbo",
                table: "Usuario",
                column: "IdTipoIdentificacion",
                principalSchema: "dbo",
                principalTable: "TipoDeIdentificacion",
                principalColumn: "TipoIdentificacionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Item_IdItem",
                schema: "dbo",
                table: "Inventario");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Rol_IdRol",
                schema: "dbo",
                table: "Inventario");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Rol_RolId",
                schema: "dbo",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_TipoDeIdentificacion_TipoDeIdentificacionTipoIdentificacionId",
                schema: "dbo",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Tesoreria_Rol_IdRol",
                schema: "dbo",
                table: "Tesoreria");

            migrationBuilder.DropForeignKey(
                name: "FK_Tesoreria_TipodeDisponible_IdTipoDisponible",
                schema: "dbo",
                table: "Tesoreria");

            migrationBuilder.DropForeignKey(
                name: "FK_TipodeDisponible_Rol_RolId",
                schema: "dbo",
                table: "TipodeDisponible");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeIdentificacion_Rol_RolId",
                schema: "dbo",
                table: "TipoDeIdentificacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                schema: "dbo",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoDeIdentificacion_IdTipoIdentificacion",
                schema: "dbo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdRol",
                schema: "dbo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdTipoIdentificacion",
                schema: "dbo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeIdentificacion_RolId",
                schema: "dbo",
                table: "TipoDeIdentificacion");

            migrationBuilder.DropIndex(
                name: "IX_TipodeDisponible_RolId",
                schema: "dbo",
                table: "TipodeDisponible");

            migrationBuilder.DropIndex(
                name: "IX_Tesoreria_IdRol",
                schema: "dbo",
                table: "Tesoreria");

            migrationBuilder.DropIndex(
                name: "IX_Tesoreria_IdTipoDisponible",
                schema: "dbo",
                table: "Tesoreria");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_TipoDeIdentificacionTipoIdentificacionId",
                schema: "dbo",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Item_RolId",
                schema: "dbo",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Inventario_IdItem",
                schema: "dbo",
                table: "Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Inventario_IdRol",
                schema: "dbo",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "RolId",
                schema: "dbo",
                table: "TipoDeIdentificacion");

            migrationBuilder.DropColumn(
                name: "RolId",
                schema: "dbo",
                table: "TipodeDisponible");

            migrationBuilder.DropColumn(
                name: "TipoDeIdentificacionTipoIdentificacionId",
                schema: "dbo",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "RolId",
                schema: "dbo",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "IdTipoIdentificacion",
                schema: "dbo",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
