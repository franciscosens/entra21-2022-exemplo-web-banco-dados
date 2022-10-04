using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    public class ConsultaMapeamento : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("consultas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Procedimento)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("procedimento"); // NOT NULL

            builder.Property(x => x.VeterinarioId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("veterinario_id"); // NOT NULL

            builder.Property(x => x.PetId)
            .HasColumnType("INT")
            .IsRequired()
            .HasColumnName("pet_id"); // NOT NULL

            builder.Property(x => x.Valor)
                .HasColumnType("DECIMAL")
                .HasPrecision(10, 2)
                .IsRequired()
                .HasColumnName("valor"); // NOT NULL

            builder.Property(x => x.Status)
            .HasColumnType("TINYINT")
            .IsRequired()
            .HasColumnName("status"); // NOT NULL

            builder.Property(x => x.DataHoraPrevista)
            .HasColumnType("DATETIME2")
            .IsRequired()
            .HasColumnName("data_hora_prevista"); // NOT NULL

            builder.Property(x => x.DataHoraFim)
            .HasColumnType("DATETIME2")
            .HasColumnName("data_hora_fim");

            builder.Property(x => x.DataHoraInicio)
            .HasColumnType("DATETIME2")
            .HasColumnName("data_hora_inicio");

            builder.Property(x => x.DataHoraCancelamento)
            .HasColumnType("DATETIME2")
            .HasColumnName("data_hora_cancelamento");

            builder.HasOne(x => x.Pet)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.PetId);

            builder.HasOne(x => x.Veterinario)
                .WithMany(x => x.Consultas)
                .HasForeignKey(x => x.VeterinarioId);
        }
    }
}