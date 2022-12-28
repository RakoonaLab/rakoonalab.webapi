﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Consultas;

namespace rakoona.services.Entities.Maps.Consultas
{
    public class ConsultaBasicaMap : IEntityTypeConfiguration<ConsultaBasica>
    {
        public void Configure(EntityTypeBuilder<ConsultaBasica> builder)
        {
            builder.ToTable(name: "ConsultasBasicas");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.Peso).HasColumnName("Peso");
            builder.Property(c => c.Temperatura).HasColumnName("Temperatura");
            builder.Property(c => c.FrecuenciaRespiratoria).HasColumnName("FrecuenciaRespiratoria");
            builder.Property(c => c.Pulso).HasColumnName("Pulso");
            builder.Property(c => c.CaracteristicasDelPulso).HasColumnName("CaracteristicasDelPulso");
            builder.Property(c => c.Motivo).HasColumnName("Motivo");

            builder.Property(c => c.Observaciones).HasColumnName("Observaciones");
            builder.Property(c => c.Diagnostico).HasColumnName("Diagnostico");
            builder.Property(c => c.Fecha).HasColumnName("Fecha");

            builder.Property(c => c.MascotaRef).HasColumnName("MascotaRef");

            #endregion

            #region Discriminator
            #endregion

            #region HasOne
            builder.HasOne(a => a.Mascota)
                    .WithMany(b => b.ConsultasBasicas)
                    .HasForeignKey(b => b.MascotaRef);

            #endregion

            #region HasMany

            #endregion
        }

    }
}
