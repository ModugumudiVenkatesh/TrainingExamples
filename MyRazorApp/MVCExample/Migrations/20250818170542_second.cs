using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCExample.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "categID",
                table: "Products",
                newName: "CategID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categID",
                table: "Products",
                newName: "IX_Products_CategID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategID",
                table: "Products",
                column: "CategID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategID",
                table: "Products",
                newName: "categID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategID",
                table: "Products",
                newName: "IX_Products_categID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categID",
                table: "Products",
                column: "categID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
