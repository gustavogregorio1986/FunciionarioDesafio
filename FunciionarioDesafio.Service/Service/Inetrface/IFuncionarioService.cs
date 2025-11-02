using FunciionarioDesafio.Data.DTO;
using FunciionarioDesafio.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Service.Service.Inetrface
{
    public interface IFuncionarioService
    {
        Task<Funcionario> AdicionarFuncionario(Funcionario funcionario);

        Task<string> BuscarPorNomeAsync(string nome);

        Task<PaginadoDTO<FuncionarioDTO>> ListarPaginadoAsync(FuncionarioFiltroDTO filtro);

        int CalcularAnosNaEmpresa(DateTime dataEntrada, DateTime dataTermino);

        Task<PaginadoDTO<Funcionario>> BuscarConcluidosAsync(int pagina, int tamanho);

        Task<PaginadoDTO<Funcionario>> BuscarTrabalhandoAsync(int pagina, int tamanho);
    }
}
