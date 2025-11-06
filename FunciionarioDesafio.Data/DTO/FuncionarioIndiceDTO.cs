using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.DTO
{
    public class FuncionarioIndiceDTO
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public decimal IndiceSalarial { get; set; }
    }
}

