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
    }
}
