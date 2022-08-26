using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class PetMapeamento : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnName("nome"); // NOT NULL

        builder.Property(x => x.Idade)
            .HasColumnType("TINYINT")
            .IsRequired()
            .HasColumnName("idade"); // NOT NULL

        builder.Property(x => x.Peso)
            .HasColumnType("DECIMAL")
            .HasPrecision(5, 2)
            .IsRequired()
            .HasColumnName("peso"); // NOT NULL

        builder.Property(x => x.Altura)
            .HasColumnType("DECIMAL")
            .HasPrecision(3, 2)
            .IsRequired()
            .HasColumnName("altura"); // NOT NULL

        builder.Property(x => x.Genero)
            .HasColumnType("TINYINT")
            .IsRequired()
            .HasColumnName("genero"); // NOT NULL

        builder.Property(x => x.ResponsavelId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("responsavel_id"); // NOT NULL

        builder.Property(x => x.RacaId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("raca_id"); // NOT NULL

        builder.Property(x => x.CaminhoArquivo)
            .HasColumnType("VARCHAR")
            .HasMaxLength(300)
            .HasColumnName("caminho_arquivo");

        builder.HasOne(x => x.Responsavel)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.ResponsavelId);

        builder.HasOne(x => x.Raca)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.RacaId);

        builder.HasData(new Pet
        {
            Id = 1,
            Nome = "Mimi",
            Genero = PetGenero.Masculino,
            Peso = 20.40m,
            Altura = 0.90m,
            Idade = 8,
            RacaId = 1,
            ResponsavelId = 1
        });
    }
}