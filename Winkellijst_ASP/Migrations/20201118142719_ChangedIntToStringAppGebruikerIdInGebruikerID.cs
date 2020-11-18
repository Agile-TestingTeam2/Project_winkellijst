using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class ChangedIntToStringAppGebruikerIdInGebruikerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppGebruikerId",
                schema: "Winkellijst",
                table: "Gebruiker",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AppGebruikerId",
                schema: "Winkellijst",
                table: "Gebruiker",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
