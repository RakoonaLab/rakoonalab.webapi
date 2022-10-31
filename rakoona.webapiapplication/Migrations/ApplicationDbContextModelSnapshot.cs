﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rakoona.webapiapplication.Context;

#nullable disable

namespace rakoona.webapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("rakoona.webapi.Entities.Models.ClienteClinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    b.Property<int>("ClinicaId")
                        .HasColumnType("int")
                        .HasColumnName("ClinicaId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ClinicaId");

                    b.ToTable("ClienteClinica", (string)null);
                });

            modelBuilder.Entity("rakoona.webapi.Entities.Models.ClinicaMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClinicaId")
                        .HasColumnType("int")
                        .HasColumnName("ClinicaId");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int")
                        .HasColumnName("MedicoId");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("MedicoId");

                    b.ToTable("ClinicaMedicos", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Clinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Direccion");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ExternalId");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeCreacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Telefono");

                    b.Property<string>("UserRef")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("UserRef");

                    b.HasKey("Id");

                    b.HasIndex("UserRef");

                    b.ToTable("Clinicas", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Consultas.ConsultaBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Diagnostico");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ExternalId");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeCreacion");

                    b.Property<int>("MascotaRef")
                        .HasColumnType("int")
                        .HasColumnName("MascotaRef");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observaciones");

                    b.HasKey("Id");

                    b.HasIndex("MascotaRef");

                    b.ToTable("Consultas", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Dosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ExternalId");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeCreacion");

                    b.Property<string>("MedicamentoRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MedicamentoRef");

                    b.Property<int>("RecetaRef")
                        .HasColumnType("int")
                        .HasColumnName("RecetaRef");

                    b.HasKey("Id");

                    b.HasIndex("RecetaRef");

                    b.ToTable("Dosis", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Pacientes.PacienteBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ExternalId");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeCreacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Personas.PersonaBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ExternalId");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeCreacion");

                    b.Property<DateTime?>("Nacimiento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Nacimiento");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PrimerApellido");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PrimerNombre");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SegundoApellido");

                    b.Property<string>("SegundoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SegundoNombre");

                    b.Property<string>("UsuarioRef")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioRef")
                        .IsUnique()
                        .HasFilter("[UsuarioRef] IS NOT NULL");

                    b.ToTable("Personas", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("PersonaBase");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConsultaRef")
                        .HasColumnType("int")
                        .HasColumnName("ConsultaRef");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ExternalId");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeCreacion");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaRef");

                    b.ToTable("Recetas", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Seguridad.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("NormalizedEmail");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("NormalizedUserName");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Pacientes.Mascota", b =>
                {
                    b.HasBaseType("rakoona.webapiapplication.Entities.Models.Pacientes.PacienteBase");

                    b.Property<int>("DuenioRef")
                        .HasColumnType("int")
                        .HasColumnName("DuenioRef");

                    b.HasIndex("DuenioRef");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Personas.Cliente", b =>
                {
                    b.HasBaseType("rakoona.webapiapplication.Entities.Models.Personas.PersonaBase");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Personas.Medico", b =>
                {
                    b.HasBaseType("rakoona.webapiapplication.Entities.Models.Personas.PersonaBase");

                    b.HasDiscriminator().HasValue("Medico");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Seguridad.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Seguridad.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rakoona.webapiapplication.Entities.Models.Seguridad.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Seguridad.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rakoona.webapi.Entities.Models.ClienteClinica", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Personas.Cliente", "Cliente")
                        .WithMany("ClienteClinicas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rakoona.webapiapplication.Entities.Models.Clinica", "Clinica")
                        .WithMany("ClienteClinicas")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("rakoona.webapi.Entities.Models.ClinicaMedico", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Clinica", "Clinica")
                        .WithMany("ClinicaMedicos")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rakoona.webapiapplication.Entities.Models.Personas.Medico", "Medico")
                        .WithMany("ClinicaMedicos")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Clinica", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Seguridad.User", "Usuario")
                        .WithMany("Clinicas")
                        .HasForeignKey("UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Consultas.ConsultaBase", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Pacientes.Mascota", "Mascota")
                        .WithMany("Consultas")
                        .HasForeignKey("MascotaRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Dosis", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Receta", "Receta")
                        .WithMany("Dosis")
                        .HasForeignKey("RecetaRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Personas.PersonaBase", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Seguridad.User", "User")
                        .WithOne("Persona")
                        .HasForeignKey("rakoona.webapiapplication.Entities.Models.Personas.PersonaBase", "UsuarioRef");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Receta", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Consultas.ConsultaBase", "Consulta")
                        .WithMany("Recetas")
                        .HasForeignKey("ConsultaRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Pacientes.Mascota", b =>
                {
                    b.HasOne("rakoona.webapiapplication.Entities.Models.Personas.Cliente", "Duenio")
                        .WithMany("Mascotas")
                        .HasForeignKey("DuenioRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rakoona.webapiapplication.Entities.Models.Pacientes.PacienteBase", null)
                        .WithOne()
                        .HasForeignKey("rakoona.webapiapplication.Entities.Models.Pacientes.Mascota", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Duenio");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Clinica", b =>
                {
                    b.Navigation("ClienteClinicas");

                    b.Navigation("ClinicaMedicos");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Consultas.ConsultaBase", b =>
                {
                    b.Navigation("Recetas");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Receta", b =>
                {
                    b.Navigation("Dosis");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Seguridad.User", b =>
                {
                    b.Navigation("Clinicas");

                    b.Navigation("Persona")
                        .IsRequired();
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Pacientes.Mascota", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Personas.Cliente", b =>
                {
                    b.Navigation("ClienteClinicas");

                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("rakoona.webapiapplication.Entities.Models.Personas.Medico", b =>
                {
                    b.Navigation("ClinicaMedicos");
                });
#pragma warning restore 612, 618
        }
    }
}
