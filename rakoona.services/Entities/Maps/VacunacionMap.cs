﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class VacunacionMap : IEntityTypeConfiguration<Vacunacion>
    {
        public void Configure(EntityTypeBuilder<Vacunacion> builder)
        {
            builder.ToTable(name: "Vacunaciones");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.FechaDeAplicacion).HasColumnName("FechaDeAplicacion");

            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.Lote).HasColumnName("Lote");
            builder.Property(c => c.Caducidad).HasColumnName("Caducidad");
            builder.Property(c => c.Laboratorio).HasColumnName("Laboratorio");

            #endregion

            #region Discriminator

            #endregion

            #region HasOne
            builder.HasOne(a => a.Consulta)
                    .WithMany(b => b.Vacunas)
                    .HasForeignKey(b => b.ConsultaRef)
                    .OnDelete(DeleteBehavior.Cascade);
            #endregion


        }

    }
}
