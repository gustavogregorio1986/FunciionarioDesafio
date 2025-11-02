using AutoMapper;
using FunciionarioDesafio.Data.DTO;
using FunciionarioDesafio.Dominio.Dominio;
using FunciionarioDesafio.Service.Service.Inetrface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FunciionarioDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("boas-vindas")]
        public IActionResult BoasVindas()
        {
            return Ok("👋 Bem-vindo à API de cadastro de funcionários!");
        }

        [HttpGet("status-por-nome/{nome}")]
        public async Task<IActionResult> ObterStatusPorNome(string nome)
        {
            var status = await _service.BuscarPorNomeAsync(nome);
            return Ok($"Status de {nome}: {status}");
        }



        [HttpPost]
        [Route("AdicionarFuncionario")]
        public async Task<IActionResult> AdicionarFuncionario([FromBody] FuncionarioDTO dto)
        {
            var funcionario = _mapper.Map<Funcionario>(dto);

            try
            {
                var resultado = await _service.AdicionarFuncionario(funcionario);
                return Ok($"Funcionário cadastrado com sucesso. Bem-vindo, {resultado.NomeFuncionario}!");


            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPaginadoAsync")]
        public async Task<IActionResult> Listar([FromQuery] FuncionarioFiltroDTO filtro)
        {
            var resultado = await _service.ListarPaginadoAsync(filtro);
            return Ok(resultado);
        }

        [HttpGet("tempo")]
        public IActionResult GetTempoDeEmpresa(DateTime entrada, DateTime termino)
        {
            int anos = _service.CalcularAnosNaEmpresa(entrada, termino);
            return Ok(new { TempoDeEmpresa = anos });
        }
    }
}
