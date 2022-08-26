using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class ResponsavelMapeamento : IEntityTypeConfiguration<Responsavel>
{
    public void Configure(EntityTypeBuilder<Responsavel> builder)
    {
        builder.ToTable("responsavies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeCompleto)
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired()
            .HasColumnName("nome_completo"); // NOT NULL

        builder.Property(x => x.Idade)
            .HasColumnType("TINYINT")
            .IsRequired()
            .HasColumnName("idade"); // NOT NULL

        builder.Property(x => x.Cpf)
            .HasColumnType("VARCHAR")
            .HasMaxLength(14)
            .IsRequired()
            .HasColumnName("cpf"); // NOT NULL

        builder.HasData(
            new Responsavel
            {
                Id = 1,
                Idade = 20,
                NomeCompleto = "Francisco",
                Cpf = "123.456.789-12"
            },
            new Responsavel
            {
                Id = 2,
                Idade = 21,
                NomeCompleto = "Lucas",
                Cpf = "234.567.890-12"
            });
    }
}