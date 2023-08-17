using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.coreMigrations
{
    /// <inheritdoc />
    public partial class deleteuserOrganizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioOrganizacion");

            migrationBuilder.AddColumn<string>(
                name: "UserRef",
                table: "Organizaciones",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "fa1e3c32-a8c9-43c0-ac09-49bb6ff83ac1", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(7992) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "54587a58-3df3-42a5-9a53-fb974444a15d", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8143) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "cca41642-1fcf-4e2b-b19b-e267c32f81d4", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "c9b1e3f5-2766-4365-b55d-40c419ddca21", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8182) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "a5d887cb-fdf0-425e-8ccf-bea15265a0e6", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8068) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "33581832-3e4f-4751-aeb6-f2c0470153c8", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "8f11745c-1592-412a-b2d2-ec86fbf41f64", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "0d6bc83c-b19b-4722-bb0a-f703c46b6204", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "73284d22-b44b-4afe-815c-3fb3262de279", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8109) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "bb759a19-02ec-4a61-9000-5e1a7f216671", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "2abe8627-d8f1-4950-bc06-322df81bbd90", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "f514126e-1765-4e13-b744-6130ded4501a", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "baee6cfb-7ea3-43bd-823f-510f02a967e1", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "464a6bd2-997f-440b-9e0e-a858e587e493", new DateTime(2023, 8, 17, 14, 2, 43, 496, DateTimeKind.Local).AddTicks(8305) });

            migrationBuilder.CreateIndex(
                name: "IX_Organizaciones_UserRef",
                table: "Organizaciones",
                column: "UserRef",
                unique: true,
                filter: "[UserRef] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizaciones_AspNetUsers_UserRef",
                table: "Organizaciones",
                column: "UserRef",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizaciones_AspNetUsers_UserRef",
                table: "Organizaciones");

            migrationBuilder.DropIndex(
                name: "IX_Organizaciones_UserRef",
                table: "Organizaciones");

            migrationBuilder.DropColumn(
                name: "UserRef",
                table: "Organizaciones");

            migrationBuilder.CreateTable(
                name: "UsuarioOrganizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizacionRef = table.Column<int>(type: "int", nullable: false),
                    UserRef = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOrganizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizacion_AspNetUsers_UserRef",
                        column: x => x.UserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizacion_Organizaciones_OrganizacionRef",
                        column: x => x.OrganizacionRef,
                        principalTable: "Organizaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "0ab66a3b-83ff-4bbd-a4fe-c6875e3a68eb", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "61e6d36a-3084-4b16-bb12-c909f189d2b3", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5569) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "e3ae330c-39bc-42eb-bbcf-09dd8a7ae6d5", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "c95bb319-89f8-4c72-a046-deaf3e0f8475", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "78127e32-d2f0-428e-85e8-10056b1302f9", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "b189f8d4-92ba-47b7-a77f-bd713c9ed935", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "cf908afd-21dd-469a-9a2e-a37d5391e5e9", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "8020188a-c468-47ea-8222-20f5bd0c577c", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "f8888e5c-baee-4398-bbe4-50b0d10699ba", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "e4d22f8c-b873-49ba-bc61-2d35ce456b85", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "de67461c-c824-4c48-9558-d6f0e4dece3e", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "e3504682-d3b6-45b1-8578-6d9283606428", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(5935) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "a4e4bc6a-eaf6-4f81-ac35-869ab25cdb78", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(6154) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "89c4ea06-501a-4f6f-812f-8e2823ba9a71", new DateTime(2023, 8, 16, 23, 53, 36, 682, DateTimeKind.Local).AddTicks(6251) });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacion_OrganizacionRef",
                table: "UsuarioOrganizacion",
                column: "OrganizacionRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacion_UserRef",
                table: "UsuarioOrganizacion",
                column: "UserRef",
                unique: true);
        }
    }
}
