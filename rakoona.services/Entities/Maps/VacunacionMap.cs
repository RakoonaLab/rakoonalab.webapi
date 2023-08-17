﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models;

namespace rakoona.services.Entities.Maps
{
    public class VacunacionMap : IEntityTypeConfiguration<PlanDeVacunacion>
    {
        public void Configure(EntityTypeBuilder<PlanDeVacunacion> builder)
        {
            builder.ToTable(name: "Vacunaciones");

            #region Property 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");
            builder.Property(c => c.FechaAplicacion).HasColumnName("FechaAplicacion");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.Lote).HasColumnName("Lote");
            builder.Property(c => c.Caducidad).HasColumnName("Caducidad");
            builder.Property(c => c.Laboratorio).HasColumnName("Laboratorio");

            builder.Property(c => c.CartillaRef).HasColumnName("CartillaRef");
            builder.Property(c => c.MedicoRef).HasColumnName("MedicoRef");

            #endregion

            builder.HasOne(a => a.Cartilla)
                    .WithMany(b => b.PlanesDeVacunacion)
                    .HasForeignKey(b => b.CartillaRef)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Medico)
                    .WithMany(b => b.Vacunas)
                    .HasForeignKey(b => b.MedicoRef)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
