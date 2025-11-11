using FunciionarioDesafio.Service.Service.Inetrface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FunciionarioDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatisticaController : ControllerBase
    {
        private readonly IEstatisticaService _service;

        public EstatisticaController(IEstatisticaService service)
        {
            _service = service;
        }

        [HttpGet("por-funcao")]
        public async Task<IActionResult> ObterPorFuncao()
        {
            var resultado = await _service.GerarEstatisticaAsync();
            return Ok(resultado);
        }

        [HttpGet("por-empresa")]
        public async Task<IActionResult> ObterPorEmpresa()
        {
            var resultado = await _service.GerarEstatisticaPorEmpresaAsync();
            return Ok(resultado);
        }

        [HttpGet("por-situacoes")]
        public async Task<IActionResult> ObterPorSituacoes()
        {
            var resultado = await _service.GerarEstatisticaPorSituacoesAsync();
            return Ok(resultado);
        }

        [HttpGet("por-faixa-salarial")]
        public async Task<IActionResult> ObterPorFaixaSalarial()
        {
            var resultado = await _service.GerarEstatisticaFaixaSalarialAsync();
            return Ok(resultado);
        }
    }
}
