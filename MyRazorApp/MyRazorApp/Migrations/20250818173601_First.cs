using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRazorApp.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_catergID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_catergID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "catergID",
                table: "Products",
                newName: "CatergID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategId",
                table: "Products",
                column: "CategId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategId",
                table: "Products",
                column: "CategId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CatergID",
                table: "Products",
                newName: "catergID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_catergID",
                table: "Products",
                column: "catergID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_catergID",
                table: "Products",
                column: "catergID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
