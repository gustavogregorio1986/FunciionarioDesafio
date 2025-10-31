using FunciionarioDesafio.Data.Repository.Interface;
using FunciionarioDesafio.Dominio.Dominio;
using FunciionarioDesafio.Dominio.Enum;
using FunciionarioDesafio.Service.Service.Inetrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Service.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            if (funcionario.SituacaoEmpresa == SituacaoEmpresa.Trabalhando &&
            (funcionario.Situacao == Situacao.Suspenso || funcionario.Situacao == Situacao.Demitido))
            {
                throw new InvalidOperationException("Funcionário com status 'Trabalhando' não pode estar 'Suspenso' ou 'Demitido'.");
            }

            return await _repository.AdicionarFuncionario(funcionario);
        }
    }
}
