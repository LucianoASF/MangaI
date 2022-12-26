using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaI.Migrations
{
    public partial class BDAtualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Matriculas_MatriculaId",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaAlunos_Matriculas_MatriculaId",
                table: "NotaAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Matrizes_MatrizId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MatrizId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MatrizId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "MatriculaId",
                table: "NotaAlunos",
                newName: "MatriculaPorTurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaAlunos_MatriculaId",
                table: "NotaAlunos",
                newName: "IX_NotaAlunos_MatriculaPorTurmaId");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Matriculas",
                newName: "MatrizId");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas",
                newName: "IX_Matriculas_MatrizId");

            migrationBuilder.RenameColumn(
                name: "MatriculaId",
                table: "Frequencias",
                newName: "MatriculaPorTurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Frequencias_MatriculaId",
                table: "Frequencias",
                newName: "IX_Frequencias_MatriculaPorTurmaId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Telefones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Conteudos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatriculaPorTurmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotaFinal = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    MatriculaId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculaPorTurmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatriculaPorTurmas_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatriculaPorTurmas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_TurmaId",
                table: "Conteudos",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaPorTurmas_MatriculaId",
                table: "MatriculaPorTurmas",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaPorTurmas_TurmaId",
                table: "MatriculaPorTurmas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudos_Turmas_TurmaId",
                table: "Conteudos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_MatriculaPorTurmas_MatriculaPorTurmaId",
                table: "Frequencias",
                column: "MatriculaPorTurmaId",
                principalTable: "MatriculaPorTurmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Matrizes_MatrizId",
                table: "Matriculas",
                column: "MatrizId",
                principalTable: "Matrizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaAlunos_MatriculaPorTurmas_MatriculaPorTurmaId",
                table: "NotaAlunos",
                column: "MatriculaPorTurmaId",
                principalTable: "MatriculaPorTurmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conteudos_Turmas_TurmaId",
                table: "Conteudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_MatriculaPorTurmas_MatriculaPorTurmaId",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Matrizes_MatrizId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaAlunos_MatriculaPorTurmas_MatriculaPorTurmaId",
                table: "NotaAlunos");

            migrationBuilder.DropTable(
                name: "MatriculaPorTurmas");

            migrationBuilder.DropIndex(
                name: "IX_Conteudos_TurmaId",
                table: "Conteudos");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Conteudos");

            migrationBuilder.RenameColumn(
                name: "MatriculaPorTurmaId",
                table: "NotaAlunos",
                newName: "MatriculaId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaAlunos_MatriculaPorTurmaId",
                table: "NotaAlunos",
                newName: "IX_NotaAlunos_MatriculaId");

            migrationBuilder.RenameColumn(
                name: "MatrizId",
                table: "Matriculas",
                newName: "TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_MatrizId",
                table: "Matriculas",
                newName: "IX_Matriculas_TurmaId");

            migrationBuilder.RenameColumn(
                name: "MatriculaPorTurmaId",
                table: "Frequencias",
                newName: "MatriculaId");

            migrationBuilder.RenameIndex(
                name: "IX_Frequencias_MatriculaPorTurmaId",
                table: "Frequencias",
                newName: "IX_Frequencias_MatriculaId");

            migrationBuilder.AddColumn<int>(
                name: "MatrizId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Telefones",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MatrizId",
                table: "Usuarios",
                column: "MatrizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Matriculas_MatriculaId",
                table: "Frequencias",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaAlunos_Matriculas_MatriculaId",
                table: "NotaAlunos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Matrizes_MatrizId",
                table: "Usuarios",
                column: "MatrizId",
                principalTable: "Matrizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
