using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class GebruikerVeranderdEnDataAnnotatieFKApplicatieGebruiker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gebruiker_Email",
                schema: "Winkellijst",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Winkellijst",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "Wachtwoord",
                schema: "Winkellijst",
                table: "Gebruiker");

            migrationBuilder.AddColumn<int>(
                name: "AppGebruikerId",
                schema: "Winkellijst",
                table: "Gebruiker",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppGebruikerId",
                schema: "Winkellijst",
                table: "Gebruiker");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Winkellijst",
                table: "Gebruiker",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wachtwoord",
                schema: "Winkellijst",
                table: "Gebruiker",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_Email",
                schema: "Winkellijst",
                table: "Gebruiker",
                column: "Email",
                unique: true);
        }
    }
}
