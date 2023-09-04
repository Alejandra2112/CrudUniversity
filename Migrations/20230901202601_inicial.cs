using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudUniversity.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdEstudiante);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    grado = table.Column<int>(type: "int", nullable: true),
                    cursosIdCurso = table.Column<int>(type: "int", nullable: true),
                    estudianteIdEstudiante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.IdInscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Cursos_cursosIdCurso",
                        column: x => x.cursosIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                    table.ForeignKey(
                        name: "FK_Inscripcion_Estudiante_estudianteIdEstudiante",
                        column: x => x.estudianteIdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_cursosIdCurso",
                table: "Inscripcion",
                column: "cursosIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_estudianteIdEstudiante",
                table: "Inscripcion",
                column: "estudianteIdEstudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
