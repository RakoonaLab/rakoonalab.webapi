using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rakoona.services.Migrations
{
    /// <inheritdoc />
    public partial class EspecieRaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColoresPorMascota_Macotas_MascotaRef",
                table: "ColoresPorMascota");

            migrationBuilder.DropColumn(
                name: "Especie",
                table: "Macotas");

            migrationBuilder.DropColumn(
                name: "Raza",
                table: "Macotas");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ColoresPorMascota");

            migrationBuilder.RenameColumn(
                name: "MascotaRef",
                table: "ColoresPorMascota",
                newName: "DescripcionRef");

            migrationBuilder.RenameIndex(
                name: "IX_ColoresPorMascota_MascotaRef",
                table: "ColoresPorMascota",
                newName: "IX_ColoresPorMascota_DescripcionRef");

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

            migrationBuilder.InsertData(
                table: "ClasesDeAnimales",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[] { 1, "0ab66a3b-83ff-4bbd-a4fe-c6875e3a68eb", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4291), "Mamiforo" });

            migrationBuilder.InsertData(
                table: "Familia",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "78127e32-d2f0-428e-85e8-10056b1302f9", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4602), "Canidos" },
                    { 2, "b189f8d4-92ba-47b7-a77f-bd713c9ed935", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4658), "Félidos" },
                    { 3, "cf908afd-21dd-469a-9a2e-a37d5391e5e9", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4760), "Mustélidos" }
                });

            migrationBuilder.InsertData(
                table: "OrdenAnimal",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[] { 1, "de67461c-c824-4c48-9558-d6f0e4dece3e", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(1476), "Carnívoro" });

            migrationBuilder.InsertData(
                table: "GeneroAnimal",
                columns: new[] { "Id", "ExternalId", "FamiliaRef", "FechaDeCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "8020188a-c468-47ea-8222-20f5bd0c577c", 1, new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5086), "Canis" },
                    { 2, "f8888e5c-baee-4398-bbe4-50b0d10699ba", 2, new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5171), "Felis" },
                    { 3, "e4d22f8c-b873-49ba-bc61-2d35ce456b85", 3, new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5244), "Mustela" }
                });

            migrationBuilder.InsertData(
                table: "Especies",
                columns: new[] { "Id", "ClaseAnimalRef", "ExternalId", "FechaDeCreacion", "GeneroRef", "NombreCientifico", "NombreCorto", "OrdenAnimalRef" },
                values: new object[,]
                {
                    { 1, 1, "61e6d36a-3084-4b16-bb12-c909f189d2b3", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5569), 2, null, "Gato", 1 },
                    { 2, 1, "e3ae330c-39bc-42eb-bbcf-09dd8a7ae6d5", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5669), 1, null, "Perro", 1 },
                    { 3, 1, "c95bb319-89f8-4c72-a046-deaf3e0f8475", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5763), 3, null, "Hurón", 1 }
                });

            migrationBuilder.InsertData(
                table: "Razas",
                columns: new[] { "Id", "EspecieRef", "ExternalId", "FechaDeCreacion", "NombreCientifico", "NombreColoquial" },
                values: new object[,]
                {
                    { 1, 2, "e3504682-d3b6-45b1-8578-6d9283606428", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5935), null, "Affenpinscher" },
                    { 2, 2, "a4e4bc6a-eaf6-4f81-ac35-869ab25cdb78", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(6154), null, "Afgano" },
                    { 3, 2, "89c4ea06-501a-4f6f-812f-8e2823ba9a71", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(6251), null, "Akita" }
                });

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
                name: "IX_Razas_EspecieRef",
                table: "Razas",
                column: "EspecieRef");

            migrationBuilder.AddForeignKey(
                name: "FK_ColoresPorMascota_DescripcionesFisicasDeMascotas_DescripcionRef",
                table: "ColoresPorMascota",
                column: "DescripcionRef",
                principalTable: "DescripcionesFisicasDeMascotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColoresPorMascota_DescripcionesFisicasDeMascotas_DescripcionRef",
                table: "ColoresPorMascota");

            migrationBuilder.DropTable(
                name: "DescripcionesFisicasDeMascotas");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "ClasesDeAnimales");

            migrationBuilder.DropTable(
                name: "GeneroAnimal");

            migrationBuilder.DropTable(
                name: "OrdenAnimal");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.RenameColumn(
                name: "DescripcionRef",
                table: "ColoresPorMascota",
                newName: "MascotaRef");

            migrationBuilder.RenameIndex(
                name: "IX_ColoresPorMascota_DescripcionRef",
                table: "ColoresPorMascota",
                newName: "IX_ColoresPorMascota_MascotaRef");

            migrationBuilder.AddColumn<string>(
                name: "Especie",
                table: "Macotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Raza",
                table: "Macotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ColoresPorMascota",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ColoresPorMascota_Macotas_MascotaRef",
                table: "ColoresPorMascota",
                column: "MascotaRef",
                principalTable: "Macotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
