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
        [Route("dicionar-funcionario")]
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
        [Route("listar-paginado")]
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
        [Route("buscar-concluidos")]
        public async Task<IActionResult> GetFuncionariosConcluidos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarConcluidosAsync(pagina, tamanho);
            return Ok(resultado);


        }

        [HttpGet]
        [Route("buscar-trabalhando")]
        public async Task<IActionResult> GetFuncionariosTrablahndo([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarTrabalhandoAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-desenvolvedor")]
        public async Task<IActionResult> GetFuncionariosDesenvolvedor([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarDesenvolvedorAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-enfermeira")]
        public async Task<IActionResult> GetFuncionariosEnfermeira([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarEnfermeiraAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-inativas")]
        public async Task<IActionResult> GetFuncionariosInativos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarInativarAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-ativas")]
        public async Task<IActionResult> GetFuncionariosAtivas([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarAtivarAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-suspensos")]
        public async Task<IActionResult> GetFuncionariosSuspenso([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarSuspensoAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-empresa")]
        public async Task<IActionResult> GetFuncionariosEmpresa([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarEmpresaAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("buscar-ibm")]
        public async Task<IActionResult> BuscarIbmAsync([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var resultado = await _service.BuscarIbmAsync(pagina, tamanho);
            return Ok(resultado);
        }

        [HttpPut]
        [Route("atualizar/id")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] FuncionarioDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da URL não confere com o corpo da requisição.");

            var funcionario = new Funcionario
            {
                Id = dto.Id,
                NomeFuncionario = dto.NomeFuncionario,
                EmailFuncionario = dto.EmailFuncionario,
                Cpf = dto.Cpf,
                Celular = dto.Celular,
                EmailComporativo = dto.EmailComporativo,
                Funcao = dto.Funcao,
                Datainicio = dto.Datainicio,
                SituacaoEmpresa = dto.SituacaoEmpresa,
                DateTermino = dto.DateTermino,
                Salario = dto.Salario,
                Empresa = dto.Empresa,
                Situacao = dto.Situacao
            };

            await _service.AtualizarAsyc(funcionario);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _service.RemoverAsyc(id);
            return NoContent();
        }


        [HttpGet("obter-media-salarialAsync")]
        public async Task<IActionResult> MediaSalarial()
        {
            var media = await _service.ObterMediaSalarialAsync();
            return Ok(new { mediaSalarial = media });
        }

        [HttpGet("indice-salarial")]
        public async Task<IActionResult> IndiceSalarial([FromQuery] FuncionarioFiltroDTO filtro)
        {
            var resultado = await _service.CalcularIndiceSalarialAsync(filtro);
            return Ok(resultado);
        }

        [HttpGet("gerar-pdf")]
        public async Task<IActionResult> GerarPdf([FromQuery] FuncionarioFiltroDTO filtro)
        {
            var bytes = await _service.GerarPdfListaFuncionariosAsync(filtro);
            return File(bytes, "application/pdf", "lista-funcionarios.pdf");
        }
    }
}
