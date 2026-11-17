using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Franshelina_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class arregloVentaDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_Ventas_VentasId",
                table: "VentasDetalles");

            migrationBuilder.RenameColumn(
                name: "VentasId",
                table: "VentasDetalles",
                newName: "VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalles_VentasId",
                table: "VentasDetalles",
                newName: "IX_VentasDetalles_VentaId");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "VentasDetalles",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_Ventas_VentaId",
                table: "VentasDetalles",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_Ventas_VentaId",
                table: "VentasDetalles");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "VentasDetalles",
                newName: "VentasId");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalles_VentaId",
                table: "VentasDetalles",
                newName: "IX_VentasDetalles_VentasId");

            migrationBuilder.AlterColumn<double>(
                name: "Cantidad",
                table: "VentasDetalles",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_Ventas_VentasId",
                table: "VentasDetalles",
                column: "VentasId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
