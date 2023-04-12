using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlinikaPlusWeb.Migrations
{
    public partial class LjekarTitula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Titula",
                table: "Ljekari",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titula",
                table: "Ljekari");
        }
    }
}
