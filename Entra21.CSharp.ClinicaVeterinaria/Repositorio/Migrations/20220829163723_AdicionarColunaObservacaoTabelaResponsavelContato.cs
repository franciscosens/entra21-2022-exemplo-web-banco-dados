using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarColunaObservacaoTabelaResponsavelContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "contatos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "caminho_arquivo",
                value: "fcd3850a-cbc7-47db-b52b-5e6c8f68bdd4.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observacao",
                table: "contatos");

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "caminho_arquivo",
                value: null);
        }
    }
}
