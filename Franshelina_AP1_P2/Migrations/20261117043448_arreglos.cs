using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Franshelina_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class arreglos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Monto",
                table: "Ventas",
                newName: "Total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Ventas",
                newName: "Monto");
        }
    }
}
