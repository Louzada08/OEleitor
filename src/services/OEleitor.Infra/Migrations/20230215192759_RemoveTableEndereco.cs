using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEleitor.Infra.Migrations
{
    public partial class RemoveTableEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Eleitores");

            migrationBuilder.AddColumn<Guid>(
                name: "BairroId",
                table: "Eleitores",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eleitores_BairroId",
                table: "Eleitores",
                column: "BairroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eleitores_Bairros_BairroId",
                table: "Eleitores",
                column: "BairroId",
                principalTable: "Bairros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleitores_Bairros_BairroId",
                table: "Eleitores");

            migrationBuilder.DropIndex(
                name: "IX_Eleitores_BairroId",
                table: "Eleitores");

            migrationBuilder.DropColumn(
                name: "BairroId",
                table: "Eleitores");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Eleitores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BairroId = table.Column<Guid>(type: "uuid", nullable: false),
                    EleitorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cep = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 30, nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 2, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", maxLength: 5, nullable: true)
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
    }
}
