using FunciionarioDesafio.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Service.Service.Inetrface
{
    public interface IEstatisticaService
    {
        Task<List<EstatisticaPorFuncaoDTO>> GerarEstatisticaAsync();

        Task<List<EstatisticaPorEmpresaDTO>> GerarEstatisticaPorEmpresaAsync();

        Task<List<EstatisticaSituacaoDTO>> GerarEstatisticaPorSituacoesAsync();

        Task<List<EstatisticaFaixaSalarialDTO>> GerarEstatisticaFaixaSalarialAsync();


    }
}
