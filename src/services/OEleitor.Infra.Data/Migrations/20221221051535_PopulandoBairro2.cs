using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace OEleitor.Infra.Data.Migrations
{
    public partial class PopulandoBairro2 : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO public.\"Bairros\" (\"BairroNome\",\"DataCadastro\") VALUES('JARDIM AURENY I','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Bairros");
        }
    }
}
