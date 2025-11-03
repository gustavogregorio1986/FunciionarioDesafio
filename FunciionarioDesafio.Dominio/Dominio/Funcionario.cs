using FunciionarioDesafio.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Dominio.Dominio
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string? NomeFuncionario { get; set; }

        public string? EmailFuncionario { get; set; }

        public string? Cpf { get; set; }

        public string? Celular { get; set; }

        public string? EmailComporativo { get; set; }

        public string? Funcao { get; set; }

        public DateTime Datainicio { get; set; }

        public SituacaoEmpresa? SituacaoEmpresa { get; set; }

        public DateTime? DateTermino { get; set; }

        public decimal Salario { get; set; }

        public string? Empresa { get; set; }

        public Situacao? Situacao { get; set; }
    }
}
