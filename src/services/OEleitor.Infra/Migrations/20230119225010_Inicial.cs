using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEleitor.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BairroNome = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eleitores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: true),
                    Aniversario = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sexo = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Fone1 = table.Column<string>(type: "varchar(15)", nullable: true),
                    Fone1TemWhatsapp = table.Column<bool>(type: "boolean", nullable: true),
                    Fone2 = table.Column<string>(type: "varchar(15)", nullable: true),
                    Fone2TemWhatsapp = table.Column<bool>(type: "boolean", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleitores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EleitorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fone = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependentes_Eleitores_EleitorId",
                        column: x => x.EleitorId,
                        principalTable: "Eleitores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EleitorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", maxLength: 5, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 30, nullable: true),
                    BairroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cep = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 2, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Bairros_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enderecos_Eleitores_EleitorId",
                        column: x => x.EleitorId,
                        principalTable: "Eleitores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_EleitorId",
                table: "Dependentes",
                column: "EleitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_BairroId",
                table: "Enderecos",
                column: "BairroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EleitorId",
                table: "Enderecos",
                column: "EleitorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "Eleitores");
        }
    }
}
