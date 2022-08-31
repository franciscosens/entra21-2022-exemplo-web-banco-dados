using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class ConsultaMapeamento : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.ToTable("consultas");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.VeterinarioId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("veterinario_id");

        builder.Property(x => x.PetId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("pet_id");
        
        builder.Property(x => x.Status)
            .HasColumnType("TINYINT")
            .IsRequired()
            .HasColumnName("status");
        
        builder.Property(x => x.DataConsulta)
            .HasColumnType("DATETIME2")
            .IsRequired()
            .HasColumnName("data_consulta");
        
        builder.Property(x => x.Total)
            .HasColumnType("DECIMAL")
            .HasPrecision(10, 2)
            .IsRequired()
            .HasColumnName("total");
    }
}