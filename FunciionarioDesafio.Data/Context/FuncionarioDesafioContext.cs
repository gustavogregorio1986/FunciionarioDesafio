using FunciionarioDesafio.Data.Map;
using FunciionarioDesafio.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.Context
{
    public class FuncionarioDesafioContext : DbContext
    {
        public FuncionarioDesafioContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }    
    }
}
