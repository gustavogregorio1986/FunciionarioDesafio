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
    }
}
