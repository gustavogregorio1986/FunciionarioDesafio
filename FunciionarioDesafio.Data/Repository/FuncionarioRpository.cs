using FunciionarioDesafio.Data.Context;
using FunciionarioDesafio.Data.Repository.Interface;
using FunciionarioDesafio.Dominio.Dominio;
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


    }
}

