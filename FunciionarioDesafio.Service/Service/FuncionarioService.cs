﻿using FunciionarioDesafio.Data.DTO;
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
                NomeFuncionario = f.NomeFuncionario,
                EmailComporativo = f.EmailComporativo
            });

            return new PaginadoDTO<FuncionarioDTO>(dtos, filtro.Pagina, filtro.TamanhoPagina, total);


        }
    }
}
