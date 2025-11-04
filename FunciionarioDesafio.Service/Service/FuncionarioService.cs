using FunciionarioDesafio.Data.DTO;
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

        public void ValidarDatas(DateTime dataInicio, DateTime? dateTermino)
        {
            if (dateTermino < dataInicio)
            {
                throw new ArgumentException("A data de término não pode ser menor que a data de início.");
            }
        }


        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            ValidarDatas(funcionario.Datainicio, funcionario.DateTermino);

            if (funcionario.SituacaoEmpresa == SituacaoEmpresa.Trabalhando &&
            (funcionario.Situacao == Situacao.Suspenso || funcionario.Situacao == Situacao.Demitido))
            {
                throw new InvalidOperationException("Funcionário com status 'Trabalhando' não pode estar 'Suspenso' ou 'Demitido'.");
            }

            if (funcionario.SituacaoEmpresa == SituacaoEmpresa.Concluido &&
                  funcionario.Situacao != Situacao.Inativo)
            {
                throw new InvalidOperationException("Funcionário com vínculo 'Concluído' só pode estar 'Inativo'.");
            }



            return await _repository.AdicionarFuncionario(funcionario);
        }

        private string CalcularStatus(Funcionario funcionario)
        {
            var hoje = DateTime.Today;

            if (funcionario.Situacao == Situacao.Ativo &&
                funcionario.Datainicio <= hoje &&
                funcionario.DateTermino == null)
                return "Admissão";

            if (funcionario.Situacao == Situacao.Suspenso)
                return "Suspenso";

            if (funcionario.DateTermino.HasValue && funcionario.DateTermino.Value < hoje)
                return "Encerrar vínculo";

            return "Status indefinido";
        }

        public int CalcularAnosNaEmpresa(DateTime dataEntrada, DateTime dataTermino)
        {
            int anos = dataTermino.Year - dataEntrada.Year;

            if (dataTermino < dataEntrada.AddYears(anos))
            {
                anos--;
            }

            return anos;
        }

        public async Task<string> BuscarPorNomeAsync(string nome)
        {
            var funcionario = await _repository.BuscarPorNomeAsync(nome);

            if (funcionario == null)
                return "Funcionário não encontrado.";

            return CalcularStatus(funcionario); // ✅ Aqui retorna só o texto do status


        }

        public async Task<PaginadoDTO<FuncionarioDTO>> ListarPaginadoAsync(FuncionarioFiltroDTO filtro)
        {
            var (entidades, total) = await _repository.BuscarComFiltroAsync(filtro);

            var dtos = entidades.Select(f => new FuncionarioDTO
            {
                Id = f.Id,
                NomeFuncionario = f.NomeFuncionario,
                EmailFuncionario = f.EmailFuncionario,
                Cpf = f.Cpf,
                Celular = f.Celular,
                EmailComporativo = f.EmailComporativo,
                Funcao = f.Funcao,
                Datainicio = f.Datainicio,
                SituacaoEmpresa = f.SituacaoEmpresa,
                DateTermino = f.DateTermino,
                Salario = f.Salario,
                Empresa = f.Empresa,
                Situacao = f.Situacao
            });

            return new PaginadoDTO<FuncionarioDTO>(dtos, filtro.Pagina, filtro.TamanhoPagina, total);


        }

        public async Task<PaginadoDTO<Funcionario>> BuscarConcluidosAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                SituacaoEmpresa = SituacaoEmpresa.Concluido
            };

            var (funcionarios, total) = await _repository.BuscarComFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }

        public async Task<PaginadoDTO<Funcionario>> BuscarTrabalhandoAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                SituacaoEmpresa = SituacaoEmpresa.Trabalhando
            };

            var (funcionarios, total) = await _repository.BuscarComFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }

        public async Task<PaginadoDTO<Funcionario>> BuscarAtivarAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                Situacao = Situacao.Ativo
            };

            var (funcionarios, total) = await _repository.BuscarAtivarFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }

        public async Task<PaginadoDTO<Funcionario>> BuscarInativarAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                Situacao = Situacao.Inativo
            };

            var (funcionarios, total) = await _repository.BuscarInativarFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }

        public async Task<PaginadoDTO<Funcionario>> BuscarSuspensoAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                Situacao = Situacao.Suspenso
            };

            var (funcionarios, total) = await _repository.BuscarSuspensoFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }

        public async Task<PaginadoDTO<Funcionario>> BuscarDesenvolvedorAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                Funcao = "Desenvolvedor"
            };

            var (funcionarios, total) = await _repository.BuscarDesenvolvedorFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }

        public async Task<PaginadoDTO<Funcionario>> BuscarEnfermeiraAsync(int pagina, int tamanho)
        {
            var filtro = new FuncionarioFiltroDTO
            {
                Pagina = pagina,
                TamanhoPagina = tamanho,
                Funcao = "Enfermeira"
            };

            var (funcionarios, total) = await _repository.BuscarEnfermerioFiltroAsync(filtro);

            return new PaginadoDTO<Funcionario>(
                funcionarios,
                pagina,
                tamanho,
                total
            );
        }
    }

}
