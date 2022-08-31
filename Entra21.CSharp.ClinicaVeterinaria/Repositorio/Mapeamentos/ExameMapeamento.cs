using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class ExameMapeamento : IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder.ToTable("exames");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnName("nome");

        builder.Property(x => x.Preco)
            .HasColumnType("DECIMAL")
            .HasPrecision(9, 2)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT")
            .HasColumnName("descricao");

        var id = 0;
        
        builder.HasData(
            GerarExame(++id, "Consulta Pediatrica", 249.90m),
            GerarExame(++id, "Atendimento odontológico", 249.90m, "Avaliação periodontal"),
            GerarExame(++id, "Corte de unha", 60.00m),
            GerarExame(++id, "Fluidoterapia subcutânea", 175.00m),
            GerarExame(++id, "Curativos ", 150.00m, "Aplicação de ataduras e imobilização"),
            GerarExame(++id, "Coleta de exames", 70m),
            GerarExame(++id, "Administração de medicamento via oral", 50m),
            GerarExame(++id, "Ultrassom", 149.99m),
            GerarExame(++id, "Ressonância magnética", 900.75m));
    }

    private Exame GerarExame(int id, string nome, decimal preco, string? descricao = null) =>
        new Exame
        {
            Id = id,
            Nome = nome,
            Preco = preco,
            Descricao = descricao
        };
}