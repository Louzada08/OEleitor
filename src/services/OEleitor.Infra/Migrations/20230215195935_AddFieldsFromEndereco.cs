using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEleitor.Infra.Migrations
{
    public partial class AddFieldsFromEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cep",
                table: "Eleitores",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Eleitores",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Eleitores",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Estado",
                table: "Eleitores",
                type: "varchar(02)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Logradouro",
                table: "Eleitores",
                type: "varchar(80)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Numero",
                table: "Eleitores",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Eleitores");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Eleitores");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Eleitores");

            migrationBuilder.DropColumn(
                name: "Endereco_Estado",
                table: "Eleitores");

            migrationBuilder.DropColumn(
                name: "Endereco_Logradouro",
                table: "Eleitores");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Eleitores");
        }
    }
}
