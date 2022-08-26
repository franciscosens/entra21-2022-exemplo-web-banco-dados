using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarRacaVeterinarioResponsavelContatoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "racas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    especie = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "responsavies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_completo = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    idade = table.Column<byte>(type: "TINYINT", nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsavies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "veterinarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Crmv = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    Idade = table.Column<int>(type: "INT", nullable: true),
                    Salario = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true),
                    Empregado = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<byte>(type: "TINYINT", nullable: false),
                    valor = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contatos_responsavies_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "responsavies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "racas",
                columns: new[] { "Id", "especie", "nome" },
                values: new object[,]
                {
                    { 1, "Gato", "Frajola" },
                    { 2, "Capivara", "Piupiu" }
                });

            migrationBuilder.InsertData(
                table: "responsavies",
                columns: new[] { "Id", "cpf", "idade", "nome_completo" },
                values: new object[,]
                {
                    { 1, "123.456.789-12", (byte)20, "Francisco" },
                    { 2, "234.567.890-12", (byte)21, "Lucas" }
                });

            migrationBuilder.InsertData(
                table: "veterinarios",
                columns: new[] { "Id", "Crmv", "Idade", "Nome", "Salario" },
                values: new object[,]
                {
                    { 1, "66666SC", null, "Amanda", null },
                    { 2, "89898SC", null, "Gui", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatos_ResponsavelId",
                table: "contatos",
                column: "ResponsavelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "racas");

            migrationBuilder.DropTable(
                name: "veterinarios");

            migrationBuilder.DropTable(
                name: "responsavies");
        }
    }
}
