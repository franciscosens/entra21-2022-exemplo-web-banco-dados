using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Migrations
{
    public partial class AdicionarRacaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    valor_efetivo = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedimentos", x => x.Id);
                });

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
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    observacao = table.Column<string>(type: "TEXT", nullable: true)
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
                    caminho_arquivo = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pet_id = table.Column<int>(type: "INT", nullable: false),
                    veterinario_id = table.Column<int>(type: "INT", nullable: false),
                    valor_previsto = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    valor_efetivo = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    status = table.Column<byte>(type: "TINYINT", nullable: false),
                    motivo_cancelamento = table.Column<string>(type: "TEXT", nullable: true),
                    procedimento = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    data_hora_prevista = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    data_hora_fim = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    data_hora_cancelamento = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    data_hora_inicio = table.Column<DateTime>(type: "DATETIME2", nullable: true)
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
                name: "consultas_procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    procedimento_id = table.Column<int>(type: "INT", nullable: false),
                    consulta_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas_procedimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consultas_procedimentos_consultas_consulta_id",
                        column: x => x.consulta_id,
                        principalTable: "consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultas_procedimentos_procedimentos_procedimento_id",
                        column: x => x.procedimento_id,
                        principalTable: "procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "procedimentos",
                columns: new[] { "Id", "nome", "valor_efetivo" },
                values: new object[,]
                {
                    { 1, "Raio X", 200.90m },
                    { 2, "Hemograma", 190.90m },
                    { 3, "Exame de urina", 29.99m },
                    { 4, "Função hepática", 155.90m }
                });

            migrationBuilder.InsertData(
                table: "racas",
                columns: new[] { "Id", "especie", "nome" },
                values: new object[,]
                {
                    { 1, "Gato", "Persa" },
                    { 2, "Cachorro", "Akita Inu" },
                    { 3, "Cachorro", "São-bernardo" },
                    { 4, "Gato", "Ragdoll" },
                    { 5, "Gato", "Siberiano" }
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
                values: new object[] { 1, "66666SC", null, "Amanda", null });

            migrationBuilder.InsertData(
                table: "veterinarios",
                columns: new[] { "Id", "Crmv", "Empregado", "Idade", "Nome", "Salario" },
                values: new object[] { 2, "89898SC", true, 30, "Gui", 20391.20m });

            migrationBuilder.InsertData(
                table: "contatos",
                columns: new[] { "Id", "observacao", "ResponsavelId", "tipo", "valor" },
                values: new object[,]
                {
                    { 1, "Sem observação", 1, (byte)0, "francisco@gmail.com" },
                    { 2, null, 1, (byte)2, "(47) 98801-6374" },
                    { 3, null, 2, (byte)2, "(47) 99999-6374" }
                });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "Id", "altura", "caminho_arquivo", "genero", "idade", "nome", "peso", "raca_id", "responsavel_id" },
                values: new object[,]
                {
                    { 1, 0.90m, "8BE47EBF-0F7A-455F-B4DB-58001DD9D577.jpg", (byte)0, (byte)8, "PerMimi", 20.40m, 1, 1 },
                    { 2, 0.50m, "275E5840-F48D-4E7B-9156-D038C9AB89B4.jpg", (byte)0, (byte)7, "RagMimo", 14.0m, 4, 1 },
                    { 3, 0.45m, "AC74D02A-D3FB-4810-BD05-1A9E46A212CC.webp", (byte)1, (byte)7, "SibMoa", 25.0m, 5, 2 },
                    { 4, 1.10m, "E9B453D3-A676-4433-ABB1-05CCE015AA8F.jpg", (byte)1, (byte)5, "AkitMae", 15.60m, 2, 2 },
                    { 5, 1.10m, "97CCCBCC-B8F9-4E49-AA64-509F3CE65686.webp", (byte)1, (byte)5, "SaoMio", 15.60m, 3, 2 },
                    { 6, 1.10m, "04082D96-249D-4F20-B6C9-9E2FC2C947CB.webp", (byte)1, (byte)5, "SaoMão", 15.60m, 3, 1 }
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
                name: "IX_consultas_procedimentos_consulta_id",
                table: "consultas_procedimentos",
                column: "consulta_id");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_procedimentos_procedimento_id",
                table: "consultas_procedimentos",
                column: "procedimento_id");

            migrationBuilder.CreateIndex(
                name: "IX_contatos_ResponsavelId",
                table: "contatos",
                column: "ResponsavelId");

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
                name: "consultas_procedimentos");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "consultas");

            migrationBuilder.DropTable(
                name: "procedimentos");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "veterinarios");

            migrationBuilder.DropTable(
                name: "racas");

            migrationBuilder.DropTable(
                name: "responsavies");
        }
    }
}
