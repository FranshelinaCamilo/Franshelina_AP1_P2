using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Franshelina_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class arregloVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalle_Producto_ProductoId",
                table: "VentasDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalle_Ventas_VentasId",
                table: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentasDetalle",
                table: "VentasDetalle");

            migrationBuilder.RenameTable(
                name: "VentasDetalle",
                newName: "VentasDetalles");

            migrationBuilder.RenameColumn(
                name: "VentasId",
                table: "Ventas",
                newName: "VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalle_VentasId",
                table: "VentasDetalles",
                newName: "IX_VentasDetalles_VentasId");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalle_ProductoId",
                table: "VentasDetalles",
                newName: "IX_VentasDetalles_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentasDetalles",
                table: "VentasDetalles",
                column: "DetalleId");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Descripcion", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "Mocca", 150.0, 10 },
                    { 2, "Cappuccino", 120.0, 10 },
                    { 3, "Latte", 130.0, 10 },
                    { 4, "Espresso", 200.0, 10 },
                    { 5, "Machiatto", 220.0, 10 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_Productos_ProductoId",
                table: "VentasDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_Ventas_VentasId",
                table: "VentasDetalles",
                column: "VentasId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_Productos_ProductoId",
                table: "VentasDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_Ventas_VentasId",
                table: "VentasDetalles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentasDetalles",
                table: "VentasDetalles");

            migrationBuilder.RenameTable(
                name: "VentasDetalles",
                newName: "VentasDetalle");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "Ventas",
                newName: "VentasId");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalles_VentasId",
                table: "VentasDetalle",
                newName: "IX_VentasDetalle_VentasId");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalles_ProductoId",
                table: "VentasDetalle",
                newName: "IX_VentasDetalle_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentasDetalle",
                table: "VentasDetalle",
                column: "DetalleId");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalle_Producto_ProductoId",
                table: "VentasDetalle",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalle_Ventas_VentasId",
                table: "VentasDetalle",
                column: "VentasId",
                principalTable: "Ventas",
                principalColumn: "VentasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
