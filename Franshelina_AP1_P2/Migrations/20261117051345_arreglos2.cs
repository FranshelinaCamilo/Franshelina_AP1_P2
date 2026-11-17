using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Franshelina_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class arreglos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "VentasDetalles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "VentasDetalles",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
