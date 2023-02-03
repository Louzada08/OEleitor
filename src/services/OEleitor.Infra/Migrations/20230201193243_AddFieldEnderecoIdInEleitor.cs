using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEleitor.Infra.Migrations
{
    public partial class AddFieldEnderecoIdInEleitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Eleitores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Eleitores");
        }
    }
}
