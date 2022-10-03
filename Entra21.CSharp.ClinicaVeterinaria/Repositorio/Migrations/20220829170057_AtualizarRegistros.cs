using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AtualizarRegistros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "contatos",
                columns: new[] { "Id", "observacao", "ResponsavelId", "tipo", "valor" },
                values: new object[,]
                {
                    { 1, "Sem observação", 1, (byte)0, "francisco@gmail.com" },
                    { 2, null, 1, (byte)2, "(47) 98801-6374" },
                    { 3, null, 2, (byte)2, "(47) 99999-6374" }
                });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "caminho_arquivo", "genero", "nome" },
                values: new object[] { "8BE47EBF-0F7A-455F-B4DB-58001DD9D577.jpg", (byte)0, "PerMimi" });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "Id", "altura", "caminho_arquivo", "genero", "idade", "nome", "peso", "raca_id", "responsavel_id" },
                values: new object[] { 4, 1.10m, "E9B453D3-A676-4433-ABB1-05CCE015AA8F.jpg", (byte)1, (byte)5, "AkitMae", 15.60m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 1,
                column: "nome",
                value: "Persa");

            migrationBuilder.UpdateData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "especie", "nome" },
                values: new object[] { "Cachorro", "Akita Inu" });

            migrationBuilder.InsertData(
                table: "racas",
                columns: new[] { "Id", "especie", "nome" },
                values: new object[,]
                {
                    { 3, "Cachorro", "São-bernardo" },
                    { 4, "Gato", "Ragdoll" },
                    { 5, "Gato", "Siberiano" }
                });

            migrationBuilder.UpdateData(
                table: "veterinarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Empregado", "Idade", "Salario" },
                values: new object[] { true, 30, 20391.20m });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "Id", "altura", "caminho_arquivo", "genero", "idade", "nome", "peso", "raca_id", "responsavel_id" },
                values: new object[,]
                {
                    { 2, 0.50m, "275E5840-F48D-4E7B-9156-D038C9AB89B4.jpg", (byte)0, (byte)7, "RagMimo", 14.0m, 4, 1 },
                    { 3, 0.45m, "AC74D02A-D3FB-4810-BD05-1A9E46A212CC.webp", (byte)1, (byte)7, "SibMoa", 25.0m, 5, 2 },
                    { 5, 1.10m, "97CCCBCC-B8F9-4E49-AA64-509F3CE65686.webp", (byte)1, (byte)5, "SaoMio", 15.60m, 3, 2 },
                    { 6, 1.10m, "04082D96-249D-4F20-B6C9-9E2FC2C947CB.webp", (byte)1, (byte)5, "SaoMão", 15.60m, 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contatos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contatos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contatos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "caminho_arquivo", "genero", "nome" },
                values: new object[] { "fcd3850a-cbc7-47db-b52b-5e6c8f68bdd4.jpg", (byte)1, "Mimi" });

            migrationBuilder.UpdateData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 1,
                column: "nome",
                value: "Frajola");

            migrationBuilder.UpdateData(
                table: "racas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "especie", "nome" },
                values: new object[] { "Capivara", "Piupiu" });

            migrationBuilder.UpdateData(
                table: "veterinarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Empregado", "Idade", "Salario" },
                values: new object[] { false, null, null });
        }
    }
}
