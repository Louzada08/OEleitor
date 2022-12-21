using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEleitor.Infra.Data.Migrations
{
    public partial class PopulandoBairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Bairros\" (\"BairroNome\") VALUES('PLANO DIRETOR NORTE')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Bairros");
        }
    }
}
