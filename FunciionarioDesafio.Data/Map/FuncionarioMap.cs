using FunciionarioDesafio.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunciionarioDesafio.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("tb_Funcionario");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.NomeFuncionario)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(f => f.EmailComporativo)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

            builder.Property(f => f.Cpf)
               .IsRequired()
               .HasMaxLength(11)
               .HasColumnType("varchar(11)");

            builder.Property(f => f.Celular)
               .IsRequired()
               .HasMaxLength(10)
               .HasColumnType("varchar(10)");

            builder.Property(f => f.Datainicio)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(f => f.SituacaoEmpresa)
                .HasMaxLength(50)
                .IsRequired(false)
                .HasColumnType("varchar(50)");

            builder.Property(f => f.DateTermino)
                .IsRequired(false)
               .HasColumnType("datetime");

            builder.Property(f => f.Salario)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

            builder.Property(f => f.Empresa)
              .IsRequired()
              .HasMaxLength(50)
              .HasColumnType("varchar(50)");

            builder.Property(f => f.Situacao)
              .IsRequired()
              .HasMaxLength(50)
              .HasColumnType("varchar(50)");

        }
    }
}
