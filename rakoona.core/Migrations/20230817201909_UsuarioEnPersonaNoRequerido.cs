using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.coreMigrations
{
    /// <inheritdoc />
    public partial class UsuarioEnPersonaNoRequerido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "1ba263b9-afa7-4fd3-81c6-432372a1f283", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "b0920ae7-d585-4f05-933f-bd886cefa447", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "aa24f47b-30cb-4b94-a4fc-08e1a2a62ab4", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "64a3d64e-a3f3-45b9-b3d2-ce06a7701cf6", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "10b1c6bf-9b4f-4f5d-8f0d-397bda9c8652", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9726) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "b2c3ef84-8bcf-418b-a780-849af9b315fe", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "407a9a79-0489-417a-b7b5-9c892756ea7a", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "934c8776-fa2b-477f-92b1-940853e34928", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "c32bda63-6c88-4208-b9ad-0ea904f2bacf", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "dfd7f155-14be-4810-96f6-288a26243542", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "468d3b4a-a64c-41d5-a69a-a25697daa0f7", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "d02aecac-59ae-4f26-9ac5-f9cd6acd8896", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9849) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "2c389f16-baa2-4bf6-868c-5e3b0d2993e2", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9928) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "6b5fceb5-93c9-4d48-8c84-691a8fd41f81", new DateTime(2023, 8, 17, 14, 19, 9, 283, DateTimeKind.Local).AddTicks(9948) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
