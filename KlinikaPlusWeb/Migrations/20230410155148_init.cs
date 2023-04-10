using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlinikaPlusWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ljekari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ljekari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nalazi",
                columns: table => new
                {
                    PrijemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TekstualniOpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIVrijemeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalazi", x => x.PrijemId);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Spol = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prijemi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HitanPrijem = table.Column<bool>(type: "bit", nullable: false),
                    LjekarId = table.Column<int>(type: "int", nullable: true),
                    PacijentId = table.Column<int>(type: "int", nullable: true),
                    NalazId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijemi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prijemi_Ljekari_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekari",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prijemi_Nalazi_NalazId",
                        column: x => x.NalazId,
                        principalTable: "Nalazi",
                        principalColumn: "PrijemId");
                    table.ForeignKey(
                        name: "FK_Prijemi_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prijemi_LjekarId",
                table: "Prijemi",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijemi_NalazId",
                table: "Prijemi",
                column: "NalazId",
                unique: true,
                filter: "[NalazId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prijemi_PacijentId",
                table: "Prijemi",
                column: "PacijentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prijemi");

            migrationBuilder.DropTable(
                name: "Ljekari");

            migrationBuilder.DropTable(
                name: "Nalazi");

            migrationBuilder.DropTable(
                name: "Pacijenti");
        }
    }
}
