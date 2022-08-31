using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarExameTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Preco = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "exames",
                columns: new[] { "Id", "descricao", "nome", "Preco" },
                values: new object[,]
                {
                    { 1, null, "Consulta Pediatrica", 249.90m },
                    { 2, "Avaliação periodontal", "Atendimento odontológico", 249.90m },
                    { 3, null, "Corte de unha", 60.00m },
                    { 4, null, "Fluidoterapia subcutânea", 175.00m },
                    { 5, "Aplicação de ataduras e imobilização", "Curativos ", 150.00m },
                    { 6, null, "Coleta de exames", 70m },
                    { 7, null, "Administração de medicamento via oral", 50m },
                    { 8, null, "Ultrassom", 149.99m },
                    { 9, null, "Ressonância magnética", 900.75m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exames");
        }
    }
}
