using FunciionarioDesafio.Data.DTO;
using FunciionarioDesafio.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.Repository.Interface
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> AdicionarFuncionario(Funcionario funcionario);

        Task<Funcionario?> BuscarPorNomeAsync(string nome);

        Task<(IEnumerable<Funcionario>, int)> BuscarComFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarConcluidosFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarTrabalhandoFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarDesenvolvedorFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarEnfermerioFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarIbmFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarAtivarFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarInativarFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarSuspensoFiltroAsync(FuncionarioFiltroDTO filtro);

        Task<(IEnumerable<Funcionario>, int)> BuscarEmpresaFiltroAsync(FuncionarioFiltroDTO filtro);
    }
}
