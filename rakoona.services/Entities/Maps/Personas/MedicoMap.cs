using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rakoona.services.Entities.Models.Personas;

namespace rakoona.services.Entities.Maps.Personas
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable(name: "Medicos");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ExternalId).HasColumnName("ExternalId").HasMaxLength(250);
            builder.Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            builder.Property(c => c.PersonaRef).HasColumnName("PersonaRef");


            builder.HasOne(a => a.PersonaInfo)
                .WithOne(b => b.MedicoInfo)
                .HasForeignKey<Medico>(b => b.PersonaRef);

            builder.HasMany(a => a.ClinicaMedicos)
                .WithOne(b => b.Medico)
                .HasForeignKey(b => b.MedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Consultas)
                .WithOne(b => b.Medico)
                .HasForeignKey(b => b.MedicoRef);


        }

    }
}
