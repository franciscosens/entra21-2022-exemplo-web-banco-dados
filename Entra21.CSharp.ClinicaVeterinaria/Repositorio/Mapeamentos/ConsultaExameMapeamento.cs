using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class ConsultaExameMapeamento : IEntityTypeConfiguration<ConsultaExame>
{
    public void Configure(EntityTypeBuilder<ConsultaExame> builder)
    {
        builder.ToTable("consultas_exames");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Preco)
            .HasColumnType("DECIMAL")
            .HasPrecision(9, 2)
            .IsRequired();
        
        builder.Property(x => x.ConsultaId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("consulta_id");

        builder.Property(x => x.ExameId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("exame_id");

        builder.HasOne(x => x.Consulta)
            .WithMany(x => x.Exames)
            .HasForeignKey(x => x.ConsultaId);
        
        builder.HasOne(x => x.Exame)
            .WithMany(x => x.Consultas)
            .HasForeignKey(x => x.ExameId);
    }
}