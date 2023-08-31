using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rakoona.core.Migrations
{
    /// <inheritdoc />
    public partial class Innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClasesDeAnimales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasesDeAnimales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenAnimal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRef = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizaciones_AspNetUsers_UserRef",
                        column: x => x.UserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioRef = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_AspNetUsers_UsuarioRef",
                        column: x => x.UsuarioRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneroAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamiliaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneroAnimal_Familia_FamiliaRef",
                        column: x => x.FamiliaRef,
                        principalTable: "Familia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanRef = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    ValidoDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidoHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precios_Planes_PlanRef",
                        column: x => x.PlanRef,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dosis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicamentoRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecetaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosis_Recetas_RecetaRef",
                        column: x => x.RecetaRef,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizacionRef = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinicas_Organizaciones_OrganizacionRef",
                        column: x => x.OrganizacionRef,
                        principalTable: "Organizaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CP = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    PersonaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domicilios_Personas_PersonaRef",
                        column: x => x.PersonaRef,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacionDeContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PersonaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionDeContacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacionDeContacto_Personas_PersonaRef",
                        column: x => x.PersonaRef,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Macotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaNacimiento = table.Column<int>(type: "int", nullable: true),
                    MesNacimiento = table.Column<int>(type: "int", nullable: true),
                    AnioNacimiento = table.Column<int>(type: "int", nullable: true),
                    DuenioRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Macotas_Personas_DuenioRef",
                        column: x => x.DuenioRef,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Personas_PersonaRef",
                        column: x => x.PersonaRef,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneroRef = table.Column<int>(type: "int", nullable: false),
                    OrdenAnimalRef = table.Column<int>(type: "int", nullable: false),
                    ClaseAnimalRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_ClasesDeAnimales_ClaseAnimalRef",
                        column: x => x.ClaseAnimalRef,
                        principalTable: "ClasesDeAnimales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especies_GeneroAnimal_GeneroRef",
                        column: x => x.GeneroRef,
                        principalTable: "GeneroAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especies_OrdenAnimal_OrdenAnimalRef",
                        column: x => x.OrdenAnimalRef,
                        principalTable: "OrdenAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRef = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PrecioRef = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscripciones_AspNetUsers_UserRef",
                        column: x => x.UserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscripciones_Precios_PrecioRef",
                        column: x => x.PrecioRef,
                        principalTable: "Precios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteClinica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteClinica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteClinica_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteClinica_Personas_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cartillas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartillas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartillas_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImagenesPorMascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesPorMascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagenesPorMascota_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicaMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicaId = table.Column<int>(type: "int", nullable: false),
                    MedicoRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicaMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicaMedicos_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicaMedicos_Medicos_MedicoRef",
                        column: x => x.MedicoRef,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreColoquial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EspecieRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Razas_Especies_EspecieRef",
                        column: x => x.EspecieRef,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoRef = table.Column<int>(type: "int", nullable: false),
                    CartillaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Cartillas_CartillaRef",
                        column: x => x.CartillaRef,
                        principalTable: "Cartillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoRef",
                        column: x => x.MedicoRef,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vacunaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caducidad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicoRef = table.Column<int>(type: "int", nullable: false),
                    CartillaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacunaciones_Cartillas_CartillaRef",
                        column: x => x.CartillaRef,
                        principalTable: "Cartillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacunaciones_Medicos_MedicoRef",
                        column: x => x.MedicoRef,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DescripcionesFisicasDeMascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaRef = table.Column<int>(type: "int", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionesFisicasDeMascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescripcionesFisicasDeMascotas_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescripcionesFisicasDeMascotas_Razas_RazaRef",
                        column: x => x.RazaRef,
                        principalTable: "Razas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionDeFrecuenciaRespiratoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionDeFrecuenciaRespiratoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionDeFrecuenciaRespiratoria_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionDeFrecuenciaRespiratoria_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionDePeso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionDePeso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionDePeso_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionDePeso_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionesDePulso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesDePulso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionesDePulso_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionesDePulso_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionesDeRitmoCardiaco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesDeRitmoCardiaco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionesDeRitmoCardiaco_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionesDeRitmoCardiaco_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionesDeTemperatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    MascotaRef = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesDeTemperatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionesDeTemperatura_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicionesDeTemperatura_Macotas_MascotaRef",
                        column: x => x.MascotaRef,
                        principalTable: "Macotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColoresPorMascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRef = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColoresPorMascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColoresPorMascota_DescripcionesFisicasDeMascotas_DescripcionRef",
                        column: x => x.DescripcionRef,
                        principalTable: "DescripcionesFisicasDeMascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClasesDeAnimales",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[] { 1, "6cc0b3ea-ce29-41ae-bcd4-52005bb5f009", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(513), "Mamiforo" });

            migrationBuilder.InsertData(
                table: "Familia",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "54ecb00c-03e9-4900-aa2c-dafc9a89f0ac", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(537), "Canidos" },
                    { 2, "5314f937-e525-4355-a431-5b8d7c39ba77", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(541), "Félidos" },
                    { 3, "3f7dc2aa-0bc7-4b57-95b1-4f7c7a0b05e6", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(544), "Mustélidos" }
                });

            migrationBuilder.InsertData(
                table: "OrdenAnimal",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[] { 1, "c8627a08-0cbb-4bf8-9e7d-70004c7ee466", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(273), "Carnívoro" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "3b45fc68-f97e-4392-bd54-e0aea44041f4", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(822), "Free" },
                    { 2, "f4739456-f95b-4758-bd38-76146a0f477c", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(826), "Basico" }
                });

            migrationBuilder.InsertData(
                table: "GeneroAnimal",
                columns: new[] { "Id", "ExternalId", "FamiliaRef", "FechaDeCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "373e7269-2d29-4b16-90a7-9cd563f8f946", 1, new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(561), "Canis" },
                    { 2, "338e688f-c8c7-464c-a593-0c085430269f", 2, new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(578), "Felis" },
                    { 3, "e0684701-0e90-40fe-b5a2-935ae81abb98", 3, new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(585), "Mustela" }
                });

            migrationBuilder.InsertData(
                table: "Precios",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "PlanRef", "Tipo", "ValidoDesde", "ValidoHasta", "Valor" },
                values: new object[] { 1, "c6f75d1c-3166-4318-9008-b9097dc4b7cd", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(843), 1, 0, new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(855), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m });

            migrationBuilder.InsertData(
                table: "Especies",
                columns: new[] { "Id", "ClaseAnimalRef", "ExternalId", "FechaDeCreacion", "GeneroRef", "NombreCientifico", "NombreCorto", "OrdenAnimalRef" },
                values: new object[,]
                {
                    { 1, 1, "ce8770dc-f4d2-4101-9bd2-be359d86bc2b", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(605), 2, null, "Gato", 1 },
                    { 2, 1, "42d33ca1-d474-407e-9d3a-e39f4fd78651", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(624), 1, null, "Perro", 1 },
                    { 3, 1, "8df48dfd-129b-4437-a8c2-d0b43e47946c", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(638), 3, null, "Hurón", 1 }
                });

            migrationBuilder.InsertData(
                table: "Razas",
                columns: new[] { "Id", "EspecieRef", "ExternalId", "FechaDeCreacion", "NombreCientifico", "NombreColoquial" },
                values: new object[,]
                {
                    { 1, 2, "91b2fb5c-1c2a-4d7e-8b8a-18c86e1f3cf8", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(750), null, "Affenpinscher" },
                    { 2, 2, "d549ffb6-88ae-4f51-8854-ebbe7bbcae04", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(771), null, "Afgano" },
                    { 3, 2, "0823912f-c6c6-48f2-ab87-46534d3057a3", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(786), null, "Akita" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cartillas_MascotaRef",
                table: "Cartillas",
                column: "MascotaRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MascotaRef",
                table: "Citas",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteClinica_ClienteId",
                table: "ClienteClinica",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteClinica_ClinicaId",
                table: "ClienteClinica",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaMedicos_ClinicaId",
                table: "ClinicaMedicos",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaMedicos_MedicoRef",
                table: "ClinicaMedicos",
                column: "MedicoRef");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_OrganizacionRef",
                table: "Clinicas",
                column: "OrganizacionRef");

            migrationBuilder.CreateIndex(
                name: "IX_ColoresPorMascota_DescripcionRef",
                table: "ColoresPorMascota",
                column: "DescripcionRef");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_CartillaRef",
                table: "Consultas",
                column: "CartillaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoRef",
                table: "Consultas",
                column: "MedicoRef");

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionesFisicasDeMascotas_MascotaRef",
                table: "DescripcionesFisicasDeMascotas",
                column: "MascotaRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionesFisicasDeMascotas_RazaRef",
                table: "DescripcionesFisicasDeMascotas",
                column: "RazaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_PersonaRef",
                table: "Domicilios",
                column: "PersonaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Dosis_RecetaRef",
                table: "Dosis",
                column: "RecetaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_ClaseAnimalRef",
                table: "Especies",
                column: "ClaseAnimalRef");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_GeneroRef",
                table: "Especies",
                column: "GeneroRef");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_OrdenAnimalRef",
                table: "Especies",
                column: "OrdenAnimalRef");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroAnimal_FamiliaRef",
                table: "GeneroAnimal",
                column: "FamiliaRef");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesPorMascota_MascotaRef",
                table: "ImagenesPorMascota",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionDeContacto_PersonaRef",
                table: "InformacionDeContacto",
                column: "PersonaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Macotas_DuenioRef",
                table: "Macotas",
                column: "DuenioRef");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionDeFrecuenciaRespiratoria_ConsultaId",
                table: "MedicionDeFrecuenciaRespiratoria",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionDeFrecuenciaRespiratoria_MascotaRef",
                table: "MedicionDeFrecuenciaRespiratoria",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionDePeso_ConsultaId",
                table: "MedicionDePeso",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionDePeso_MascotaRef",
                table: "MedicionDePeso",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesDePulso_ConsultaId",
                table: "MedicionesDePulso",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesDePulso_MascotaRef",
                table: "MedicionesDePulso",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesDeRitmoCardiaco_ConsultaId",
                table: "MedicionesDeRitmoCardiaco",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesDeRitmoCardiaco_MascotaRef",
                table: "MedicionesDeRitmoCardiaco",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesDeTemperatura_ConsultaId",
                table: "MedicionesDeTemperatura",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesDeTemperatura_MascotaRef",
                table: "MedicionesDeTemperatura",
                column: "MascotaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_PersonaRef",
                table: "Medicos",
                column: "PersonaRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizaciones_UserRef",
                table: "Organizaciones",
                column: "UserRef",
                unique: true,
                filter: "[UserRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UsuarioRef",
                table: "Personas",
                column: "UsuarioRef",
                unique: true,
                filter: "[UsuarioRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Precios_PlanRef",
                table: "Precios",
                column: "PlanRef");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_EspecieRef",
                table: "Razas",
                column: "EspecieRef");

            migrationBuilder.CreateIndex(
                name: "IX_Subscripciones_PrecioRef",
                table: "Subscripciones",
                column: "PrecioRef");

            migrationBuilder.CreateIndex(
                name: "IX_Subscripciones_UserRef",
                table: "Subscripciones",
                column: "UserRef");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunaciones_CartillaRef",
                table: "Vacunaciones",
                column: "CartillaRef");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunaciones_MedicoRef",
                table: "Vacunaciones",
                column: "MedicoRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "ClienteClinica");

            migrationBuilder.DropTable(
                name: "ClinicaMedicos");

            migrationBuilder.DropTable(
                name: "ColoresPorMascota");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Dosis");

            migrationBuilder.DropTable(
                name: "ImagenesPorMascota");

            migrationBuilder.DropTable(
                name: "InformacionDeContacto");

            migrationBuilder.DropTable(
                name: "MedicionDeFrecuenciaRespiratoria");

            migrationBuilder.DropTable(
                name: "MedicionDePeso");

            migrationBuilder.DropTable(
                name: "MedicionesDePulso");

            migrationBuilder.DropTable(
                name: "MedicionesDeRitmoCardiaco");

            migrationBuilder.DropTable(
                name: "MedicionesDeTemperatura");

            migrationBuilder.DropTable(
                name: "Subscripciones");

            migrationBuilder.DropTable(
                name: "Vacunaciones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "DescripcionesFisicasDeMascotas");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "Organizaciones");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Cartillas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Macotas");

            migrationBuilder.DropTable(
                name: "ClasesDeAnimales");

            migrationBuilder.DropTable(
                name: "GeneroAnimal");

            migrationBuilder.DropTable(
                name: "OrdenAnimal");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
