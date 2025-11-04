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

        [HttpGet]
        [Route("ListarPaginado")]
        public async Task<IActionResult> Listar([FromQuery] FuncionarioFiltroDTO filtro)
        {
            var resultado = await _service.ListarPaginadoAsync(filtro);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("tempo")]
        public IActionResult GetTempoDeEmpresa(DateTime entrada, DateTime termino)
        {
            int anos = _service.CalcularAnosNaEmpresa(entrada, termino);
            return Ok(new { TempoDeEmpresa = anos });
        }

        [HttpGet]
        [Route("BuscarConcluidos")]
        public async Task<IActionResult> GetFuncionariosConcluidos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarConcluidosAsync(pagina, tamanho);
            return Ok(resultado);


        }

        [HttpGet]
        [Route("BuscarTrabalhando")]
        public async Task<IActionResult> GetFuncionariosTrablahndo([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarTrabalhandoAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("BuscarInativas")]
        public async Task<IActionResult> GetFuncionariosInativos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarInativarAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("BuscarAtivas")]
        public async Task<IActionResult> GetFuncionariosAtivas([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarAtivarAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("BuscarSuspensos")]
        public async Task<IActionResult> GetFuncionariosSuspenso([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarSuspensoAsync(pagina, tamanho);
            return Ok(resultado);
        }
    }
}
