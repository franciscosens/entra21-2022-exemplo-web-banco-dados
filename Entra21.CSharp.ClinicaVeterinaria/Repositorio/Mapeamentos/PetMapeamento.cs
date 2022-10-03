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

        builder.HasData(
            new Pet
            {
                Id = 1,
                Nome = "PerMimi",
                Genero = PetGenero.Feminino,
                Peso = 20.40m,
                Altura = 0.90m,
                Idade = 8,
                RacaId = 1,
                ResponsavelId = 1,
                CaminhoArquivo = "8BE47EBF-0F7A-455F-B4DB-58001DD9D577.jpg"
            },
            new Pet
            {
                Id = 2,
                Nome = "RagMimo",
                Genero = PetGenero.Feminino,
                Peso = 14.0m,
                Altura = 0.50m,
                Idade = 7,
                RacaId = 4,
                ResponsavelId = 1,
                CaminhoArquivo = "275E5840-F48D-4E7B-9156-D038C9AB89B4.jpg"
            },
            new Pet
            {
                Id = 3,
                Nome = "SibMoa",
                Genero = PetGenero.Masculino,
                Peso = 25.0m,
                Altura = 0.45m,
                Idade = 7,
                RacaId = 5,
                ResponsavelId = 2,
                CaminhoArquivo = "AC74D02A-D3FB-4810-BD05-1A9E46A212CC.webp"
            },
            new Pet
            {
                Id = 4,
                Nome = "AkitMae",
                Genero = PetGenero.Masculino,
                Peso = 15.60m,
                Altura = 1.10m,
                Idade = 5,
                RacaId = 2,
                ResponsavelId = 2,
                CaminhoArquivo = "E9B453D3-A676-4433-ABB1-05CCE015AA8F.jpg"
            },
            new Pet
            {
                Id = 5,
                Nome = "SaoMio",
                Genero = PetGenero.Masculino,
                Peso = 15.60m,
                Altura = 1.10m,
                Idade = 5,
                RacaId = 3,
                ResponsavelId = 2,
                CaminhoArquivo = "97CCCBCC-B8F9-4E49-AA64-509F3CE65686.webp"
            },
            new Pet
            {
                Id = 6,
                Nome = "SaoMão",
                Genero = PetGenero.Masculino,
                Peso = 15.60m,
                Altura = 1.10m,
                Idade = 5,
                RacaId = 3,
                ResponsavelId = 1,
                CaminhoArquivo = "04082D96-249D-4F20-B6C9-9E2FC2C947CB.webp"
            }
        );
    }
}