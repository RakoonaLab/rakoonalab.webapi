using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Consultas;

namespace rakoona.core.Entities.Models.Personas
{
    public class Medico : ModelBase
    {
        public int PersonaRef { get; set; }
        public Persona? PersonaInfo { get; set; }

        public ICollection<ClinicaMedico>? ClinicaMedicos { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
        public ICollection<PlanDeVacunacion>? Vacunas { get; set; }
    }

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
