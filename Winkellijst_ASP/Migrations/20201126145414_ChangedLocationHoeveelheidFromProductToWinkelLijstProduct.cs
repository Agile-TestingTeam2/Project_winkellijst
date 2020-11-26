using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class ChangedLocationHoeveelheidFromProductToWinkelLijstProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hoeveelheid",
                schema: "Winkellijst",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Hoeveelheid",
                schema: "Winkellijst",
                table: "WinkelLijstProduct",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hoeveelheid",
                schema: "Winkellijst",
                table: "WinkelLijstProduct");

            migrationBuilder.AddColumn<string>(
                name: "Hoeveelheid",
                schema: "Winkellijst",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
