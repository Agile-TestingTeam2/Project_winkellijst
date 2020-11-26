using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class AddedBeschrijvingInProductAndAantalInWinkellijstProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Aantal",
                schema: "Winkellijst",
                table: "WinkelLijstProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                schema: "Winkellijst",
                table: "Product",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aantal",
                schema: "Winkellijst",
                table: "WinkelLijstProduct");

            migrationBuilder.DropColumn(
                name: "Beschrijving",
                schema: "Winkellijst",
                table: "Product");
        }
    }
}
