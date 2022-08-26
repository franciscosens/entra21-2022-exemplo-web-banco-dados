using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class ContatoMapeamento : IEntityTypeConfiguration<ResponsavelContato>
{
    public void Configure(EntityTypeBuilder<ResponsavelContato> builder)
    {
        builder.ToTable("contatos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Tipo)
            .HasColumnType("TINYINT")
            .IsRequired()
            .HasColumnName("tipo"); // NOT NULL
        
        builder.Property(x => x.Valor)
            .HasColumnType("VARCHAR")
            .HasMaxLength(250)
            .IsRequired()
            .HasColumnName("valor"); // NOT NULL

        builder.HasOne(x => x.Responsavel)
            .WithMany(x => x.Contatos)
            .IsRequired();
    }
}