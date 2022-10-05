using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    public class ProcedimentoMapeamento : IEntityTypeConfiguration<Procedimento>
    {
        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.ToTable("procedimentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("nome"); // NOT NULL

            builder.Property(x => x.Valor)
                .HasColumnType("DECIMAL")
                .HasPrecision(10, 2)
                .HasColumnName("valor_efetivo"); // NOT NULL
            
            // Preencher a tabela de raça com registros
            builder.HasData(
                new Procedimento
                {
                    Id = 1,
                    Nome = "Raio X",
                    Valor = 200.90m
                },
                new Procedimento
                {
                    Id = 2,
                    Nome = "Hemograma",
                    Valor = 190.90m
                },
                new Procedimento
                {
                    Id = 3,
                    Nome = "Exame de urina",
                    Valor = 29.99m
                },
                new Procedimento
                {
                    Id = 4,
                    Nome = "Função hepática",
                    Valor = 155.90m
                }
            );
        }
    }
}