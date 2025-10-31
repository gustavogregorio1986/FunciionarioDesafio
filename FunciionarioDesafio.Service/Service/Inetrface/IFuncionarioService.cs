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
    }
}
