using FunciionarioDesafio.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.DTO
{
    public class FuncionarioFiltroDTO
    {
        public string? Nome { get; set; }
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;

        public SituacaoEmpresa? SituacaoEmpresa { get; set; }

        public Situacao? Situacao { get; set; }
    }
}
