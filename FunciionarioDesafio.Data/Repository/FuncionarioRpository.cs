using FunciionarioDesafio.Data.Context;
using FunciionarioDesafio.Data.Repository.Interface;
using FunciionarioDesafio.Dominio.Dominio;
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

        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            await _db.Funcionarios.AddAsync(funcionario);
            await _db.SaveChangesAsync();
            return funcionario;
        }
    }
}
