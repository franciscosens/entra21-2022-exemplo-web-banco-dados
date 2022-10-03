using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarColunaCaminhoArquivoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "caminho_arquivo",
                table: "pets",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "caminho_arquivo",
                table: "pets");
        }
    }
}
