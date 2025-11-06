using FunciionarioDesafio.Dominio.Dominio;
using FunciionarioDesafio.Dominio.Enum;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Service.Service
{
    public class ListaFuncionariosDocument : IDocument
    {
        public List<Funcionario> Funcionarios { get; }

        public ListaFuncionariosDocument(List<Funcionario> funcionarios)
        {
            Funcionarios = funcionarios;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(20);
                page.Header().Text("Lista de Funcionários").FontSize(18).Bold();
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2); // NomeFuncionario
                        columns.RelativeColumn(2); // EmailFuncionario
                        columns.RelativeColumn(2); // EmailComporativo
                        columns.RelativeColumn(2); // DataInicio
                        columns.RelativeColumn(2); // DataTermino
                        columns.RelativeColumn(2); // Situacao
                        columns.RelativeColumn(2); // Funcao
                        columns.RelativeColumn(1); // Salário
                    });

                    // Cabeçalho com fundo e borda
                    table.Header(header =>
                    {
                        string[] headers = {
            "Nome", "Email Pessoal", "Email Corporativo",
            "Início", "Término", "Situação", "Função", "Salário"
        };

                        foreach (var h in headers)
                        {
                            header.Cell().Element(CellStyle).Text(h).Bold();
                        }
                    });

                    // Linhas da tabela
                    foreach (var f in Funcionarios)
                    {
                        table.Cell().Element(CellStyle).Text(f.NomeFuncionario);
                        table.Cell().Element(CellStyle).Text(f.EmailFuncionario);
                        table.Cell().Element(CellStyle).Text(f.EmailComporativo);
                        table.Cell().Element(CellStyle).Text(f.Datainicio.ToString("dd/MM/yyyy"));
                        table.Cell().Element(CellStyle).Text(f.DateTermino?.ToString("dd/MM/yyyy") ?? "-");
                        table.Cell().Element(CellStyle).Text(f.Situacao);
                        table.Cell().Element(CellStyle).Text(f.Funcao);
                        table.Cell().Element(CellStyle).Text($"R$ {f.Salario:F2}");
                    }

                    // Estilo das células
                    IContainer CellStyle(IContainer container) => container
                        .BorderBottom(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .PaddingVertical(4)
                        .PaddingHorizontal(2);
                });
            });
        }
    }
}
