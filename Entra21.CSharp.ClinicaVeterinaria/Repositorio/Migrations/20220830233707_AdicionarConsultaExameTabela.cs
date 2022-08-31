using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarConsultaExameTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pet_id = table.Column<int>(type: "INT", nullable: false),
                    veterinario_id = table.Column<int>(type: "INT", nullable: false),
                    status = table.Column<byte>(type: "TINYINT", nullable: false),
                    data_consulta = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    total = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consultas_pets_pet_id",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultas_veterinarios_veterinario_id",
                        column: x => x.veterinario_id,
                        principalTable: "veterinarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "consultas_exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: false),
                    consulta_id = table.Column<int>(type: "INT", nullable: false),
                    exame_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas_exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consultas_exames_consultas_consulta_id",
                        column: x => x.consulta_id,
                        principalTable: "consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultas_exames_exames_exame_id",
                        column: x => x.exame_id,
                        principalTable: "exames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultas_pet_id",
                table: "consultas",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_veterinario_id",
                table: "consultas",
                column: "veterinario_id");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_exames_consulta_id",
                table: "consultas_exames",
                column: "consulta_id");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_exames_exame_id",
                table: "consultas_exames",
                column: "exame_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultas_exames");

            migrationBuilder.DropTable(
                name: "consultas");
        }
    }
}
