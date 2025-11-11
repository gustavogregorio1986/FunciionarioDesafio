using FunciionarioDesafio.Data.Context;
using FunciionarioDesafio.Data.DTO;
using FunciionarioDesafio.Data.Repository.Interface;
using FunciionarioDesafio.Dominio.Dominio;
using FunciionarioDesafio.Dominio.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.Repository
{
    public class FuncionarioRpository : IFuncionarioRepository
    {
        private readonly FuncionarioDesafioContext _db;

        public FuncionarioRpository(FuncionarioDesafioContext db)
        {
            _db = db;
        }

        private async Task ExecutarAutomacaoAsync(Funcionario funcionario)
        {
            Console.WriteLine($"[LOG] Funcionário {funcionario.NomeFuncionario} cadastrado em {DateTime.Now}");

            await Task.Run(() =>
            {
                Console.WriteLine($"[EMAIL] Enviando boas-vindas para {funcionario.EmailFuncionario}");
            });
        }

        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            await ExecutarAutomacaoAsync(funcionario);

            await _db.Funcionarios.AddAsync(funcionario);
            await _db.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario?> BuscarPorNomeAsync(string nome)
        {
            return await _db.Funcionarios
            .FirstOrDefaultAsync(f => f.NomeFuncionario == nome);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarComFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios.AsQueryable();


            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }



        public async Task<(IEnumerable<Funcionario>, int)> BuscarConcluidosFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.SituacaoEmpresa == SituacaoEmpresa.Concluido);

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarTrabalhandoFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.SituacaoEmpresa == SituacaoEmpresa.Trabalhando);

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarAtivarFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.Situacao == Situacao.Ativo);

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarInativarFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.Situacao == Situacao.Inativo);

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarSuspensoFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.Situacao == Situacao.Suspenso);

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarDesenvolvedorFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.Funcao == "Desenvolvedor");

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarEnfermerioFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.Funcao == "Enfermeira");

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarEmpresaFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
              .Where(f => f.Empresa == "petrobras");

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public async Task<(IEnumerable<Funcionario>, int)> BuscarIbmFiltroAsync(FuncionarioFiltroDTO filtro)
        {
            var query = _db.Funcionarios
             .Where(f => f.Empresa == "ibm");

            var total = await query.CountAsync();

            var funcionarios = await query
                .OrderBy(f => f.NomeFuncionario)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return (funcionarios, total);
        }

        public Task AtualizarAsc(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarAsyc(Funcionario funcionario)
        {
            _db.Funcionarios.Update(funcionario);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverAsyc(int id)
        {
            var funcionario = await ObterPorIdAsync(id);
            if (funcionario != null)
            {
                _db.Funcionarios.Remove(funcionario);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
           return await _db.Funcionarios.FindAsync(id).AsTask();
        }

        public async Task<decimal> CalcularMediaSalarialAsync()
        {
            return await _db.Funcionarios
           .Where(f => f.Salario > 0) // opcional: evita dividir por zero
           .AverageAsync(f => f.Salario);
        }

        public async Task<List<EstatisticaPorFuncaoDTO>> ObterEstatisticaPorFuncaoAsync()
        {
            return await _db.Funcionarios
            .GroupBy(f => f.Funcao)
            .Select(g => new EstatisticaPorFuncaoDTO
            {
                Funcao = g.Key,
                Quantidade = g.Count()
            })
            .ToListAsync();
        }

        public async Task<List<EstatisticaPorEmpresaDTO>> ObterEstatisticaPorEmpresaAsync()
        {
            return await _db.Funcionarios
            .GroupBy(f => f.Funcao)
            .Select(g => new EstatisticaPorEmpresaDTO
            {
                Empresa = g.Key,
                QuantidadeFuncionarios = g.Count()
            })
            .ToListAsync();
        }

        public async Task<List<EstatisticaSituacaoDTO>> ObterEstatisticaPorSituacoesAsync()
        {
            return await _db.Funcionarios
             .GroupBy(f => new { f.SituacaoEmpresa, f.Situacao })
             .Select(g => new EstatisticaSituacaoDTO
             {
                 SituacaoEmpresa = g.Key.SituacaoEmpresa.ToString(),
                 SituacaoFuncionario = g.Key.Situacao.ToString(),
                 Quantidade = g.Count()
             })
             .ToListAsync();


        }

        public async Task<List<EstatisticaFaixaSalarialDTO>> ObterEstatisticaPorFaixaSalarialAsync()
        {
            return await _db.Funcionarios
           .GroupBy(f =>
               f.Salario <= 2000 ? "Até R$2.000" :
               f.Salario <= 5000 ? "R$2.001–R$5.000" :
               "Acima de R$5.000")
           .Select(g => new EstatisticaFaixaSalarialDTO
           {
               Faixa = g.Key,
               Quantidade = g.Count()
           })
           .ToListAsync();
        }
    }
}

