using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaI.Migrations
{
    public partial class L2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnoComeco",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnoFim",
                table: "Matriculas",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoComeco",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "AnoFim",
                table: "Matriculas");
        }
    }
}
