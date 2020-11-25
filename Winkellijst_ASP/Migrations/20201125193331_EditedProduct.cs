using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class EditedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hoeveelheid",
                schema: "Winkellijst",
                table: "Product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Prijs",
                schema: "Winkellijst",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hoeveelheid",
                schema: "Winkellijst",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Prijs",
                schema: "Winkellijst",
                table: "Product");
        }
    }
}
