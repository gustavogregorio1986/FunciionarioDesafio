using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.DTO
{
    public class PaginadoDTO<T>
    {
        public IEnumerable<T> Itens { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamanhoPagina);

        public PaginadoDTO(IEnumerable<T> itens, int pagina, int tamanho, int total)
        {
            Itens = itens;
            PaginaAtual = pagina;
            TamanhoPagina = tamanho;
            TotalRegistros = total;
        }
    }
}
