using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class AddIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Winkellijst");

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                schema: "Winkellijst",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Wachtwoord = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.GebruikerId);
                });

            migrationBuilder.CreateTable(
                name: "Winkel",
                schema: "Winkellijst",
                columns: table => new
                {
                    WinkelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Winkelnaam = table.Column<string>(maxLength: 255, nullable: false),
                    Straat = table.Column<string>(maxLength: 255, nullable: false),
                    Huisnummer = table.Column<string>(maxLength: 12, nullable: false),
                    Stad = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winkel", x => x.WinkelId);
                });

            migrationBuilder.CreateTable(
                name: "Afdeling",
                schema: "Winkellijst",
                columns: table => new
                {
                    AfdelingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 255, nullable: false),
                    Volgorde = table.Column<int>(nullable: false),
                    WinkelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdeling", x => x.AfdelingId);
                    table.ForeignKey(
                        name: "FK_Afdeling_Winkel_WinkelId",
                        column: x => x.WinkelId,
                        principalSchema: "Winkellijst",
                        principalTable: "Winkel",
                        principalColumn: "WinkelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WinkelLijst",
                schema: "Winkellijst",
                columns: table => new
                {
                    WinkelLijstId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(nullable: false),
                    WinkelId = table.Column<int>(nullable: false),
                    AanmaakDatum = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelLijst", x => x.WinkelLijstId);
                    table.ForeignKey(
                        name: "FK_WinkelLijst_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalSchema: "Winkellijst",
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinkelLijst_Winkel_WinkelId",
                        column: x => x.WinkelId,
                        principalSchema: "Winkellijst",
                        principalTable: "Winkel",
                        principalColumn: "WinkelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Winkellijst",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 255, nullable: false),
                    AfdelingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalSchema: "Winkellijst",
                        principalTable: "Afdeling",
                        principalColumn: "AfdelingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afdeling_WinkelId",
                schema: "Winkellijst",
                table: "Afdeling",
                column: "WinkelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_Email",
                schema: "Winkellijst",
                table: "Gebruiker",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AfdelingId",
                schema: "Winkellijst",
                table: "Product",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Naam",
                schema: "Winkellijst",
                table: "Product",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WinkelLijst_GebruikerId",
                schema: "Winkellijst",
                table: "WinkelLijst",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelLijst_WinkelId",
                schema: "Winkellijst",
                table: "WinkelLijst",
                column: "WinkelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "WinkelLijst",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Afdeling",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Gebruiker",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Winkel",
                schema: "Winkellijst");
        }
    }
}
