using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    public class ConsultaProcedimentoMapeamento : IEntityTypeConfiguration<ConsultaProcedimento>
    {
        public void Configure(EntityTypeBuilder<ConsultaProcedimento> builder)
        {
            builder.ToTable("consultas_procedimentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ConsultaId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("consulta_id"); // NOT NULL

            builder.Property(x => x.ProcedimentoId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("procedimento_id"); // NOT NULL

            builder.HasOne(x => x.Consulta)
                .WithMany(x => x.ConsultaProcedimentos)
                .HasForeignKey(x => x.ConsultaId);

            builder.HasOne(x => x.Procedimento)
                .WithMany(x => x.ConsultaProcedimentos)
                .HasForeignKey(x => x.ProcedimentoId);
        }
    }
}