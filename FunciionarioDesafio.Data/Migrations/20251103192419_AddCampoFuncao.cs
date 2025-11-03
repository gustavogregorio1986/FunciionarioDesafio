using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunciionarioDesafio.Data.Migrations
{
    public partial class AddCampoFuncao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "tb_Funcionario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "tb_Funcionario");
        }
    }
}
