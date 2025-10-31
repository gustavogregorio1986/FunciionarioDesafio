using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunciionarioDesafio.Data.Migrations
{
    public partial class AjusteNomeFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeFuncioanrio",
                table: "tb_Funcionario",
                newName: "NomeFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeFuncionario",
                table: "tb_Funcionario",
                newName: "NomeFuncioanrio");
        }
    }
}
