using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunciionarioDesafio.Data.Migrations
{
    public partial class CriarTableFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncioanrio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EmailFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Celular = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    EmailComporativo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Datainicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    SituacaoEmpresa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DateTermino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Salario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Empresa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Situacao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Funcionario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Funcionario");
        }
    }
}
