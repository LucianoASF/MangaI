using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaI.Migrations
{
    public partial class tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conteudos_Matriculas_MatriculaId",
                table: "Conteudos");

            migrationBuilder.DropIndex(
                name: "IX_Conteudos_MatriculaId",
                table: "Conteudos");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "Conteudos");

            migrationBuilder.RenameColumn(
                name: "tema",
                table: "Conteudos",
                newName: "Tema");

            migrationBuilder.AddColumn<int>(
                name: "MatriculaId",
                table: "Frequencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Frequencias_MatriculaId",
                table: "Frequencias",
                column: "MatriculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Matriculas_MatriculaId",
                table: "Frequencias",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Matriculas_MatriculaId",
                table: "Frequencias");

            migrationBuilder.DropIndex(
                name: "IX_Frequencias_MatriculaId",
                table: "Frequencias");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "Frequencias");

            migrationBuilder.RenameColumn(
                name: "Tema",
                table: "Conteudos",
                newName: "tema");

            migrationBuilder.AddColumn<int>(
                name: "MatriculaId",
                table: "Conteudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_MatriculaId",
                table: "Conteudos",
                column: "MatriculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudos_Matriculas_MatriculaId",
                table: "Conteudos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id");
        }
    }
}
