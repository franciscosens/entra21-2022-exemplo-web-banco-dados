using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;

public class ResponsavelContatoMapeamento : IEntityTypeConfiguration<ResponsavelContato>
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

        builder.Property(x => x.Observacao)
            .HasColumnType("TEXT")
            .HasColumnName("observacao");

        builder.HasOne(x => x.Responsavel)
            .WithMany(x => x.Contatos)
            .IsRequired();

        builder.HasData(
            new ResponsavelContato
            {
                Id = 1,
                ResponsavelId = 1,
                Valor = "francisco@gmail.com",
                Tipo = ResponsavelContatoTipo.Email,
                Observacao = "Sem observação"
            },
            new ResponsavelContato
            {
                Id = 2,
                ResponsavelId = 1,
                Valor = "(47) 98801-6374",
                Tipo = ResponsavelContatoTipo.Celular
            },
            new ResponsavelContato
            {
                Id = 3,
                ResponsavelId = 2,
                Valor = "(47) 99999-6374",
                Tipo = ResponsavelContatoTipo.Celular
            }
        );
    }
}