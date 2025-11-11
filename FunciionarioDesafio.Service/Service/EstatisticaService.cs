using FunciionarioDesafio.Data.DTO;
using FunciionarioDesafio.Data.Repository.Interface;
using FunciionarioDesafio.Service.Service.Inetrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Service.Service
{
    public class EstatisticaService : IEstatisticaService
    {
        private readonly IFuncionarioRepository _repository;

        public EstatisticaService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EstatisticaPorFuncaoDTO>> GerarEstatisticaAsync()
        {
            return await _repository.ObterEstatisticaPorFuncaoAsync();
        }

        public async Task<List<EstatisticaPorEmpresaDTO>> GerarEstatisticaPorEmpresaAsync()
        {
            return await _repository.ObterEstatisticaPorEmpresaAsync();
        }

        public async Task<List<EstatisticaSituacaoDTO>> GerarEstatisticaPorSituacoesAsync()
        {
            return await _repository.ObterEstatisticaPorSituacoesAsync();
        }
    }
}
