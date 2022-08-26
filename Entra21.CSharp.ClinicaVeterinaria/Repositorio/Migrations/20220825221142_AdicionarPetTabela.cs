using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarPetTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    idade = table.Column<byte>(type: "TINYINT", nullable: false),
                    peso = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: false),
                    altura = table.Column<decimal>(type: "DECIMAL(3,2)", precision: 3, scale: 2, nullable: false),
                    genero = table.Column<byte>(type: "TINYINT", nullable: false),
                    raca_id = table.Column<int>(type: "INT", nullable: false),
                    responsavel_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pets_racas_raca_id",
                        column: x => x.raca_id,
                        principalTable: "racas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pets_responsavies_responsavel_id",
                        column: x => x.responsavel_id,
                        principalTable: "responsavies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "Id", "altura", "genero", "idade", "nome", "peso", "raca_id", "responsavel_id" },
                values: new object[] { 1, 0.90m, (byte)1, (byte)8, "Mimi", 20.40m, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_pets_raca_id",
                table: "pets",
                column: "raca_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_responsavel_id",
                table: "pets",
                column: "responsavel_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pets");
        }
    }
}
