using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    public class VeterinarioMapeamento : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            builder.HasKey(x => x.Id).HasName("Id");

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasColumnType("INT");

            builder.Property(x => x.Crmv)
                .HasColumnType("VARCHAR")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(x => x.Salario)
                .HasColumnType("DECIMAL")
                .HasPrecision(9, 2);

            builder.Property(x => x.Empregado)
                .HasColumnType("BIT")
                .HasDefaultValue(true);

            builder.HasData(
                new Veterinario
                {
                    Id = 1,
                    Nome = "Amanda",
                    Crmv = "66666SC"
                },
                new Veterinario
                {
                    Id = 2,
                    Nome = "Gui",
                    Crmv = "89898SC"
                });
        }
    }
}
