using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rakoona.coreMigrations
{
    /// <inheritdoc />
    public partial class Subscripciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "dc9b119e-a965-4ac7-81fc-13c4784abede", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "56e258c6-e09a-487c-bc80-87b137ef14a7", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "468732be-a4b6-427b-bf22-cd9fcea85df7", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "aeeb80c3-042a-4f26-8b62-fbcce5f1561e", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "7baa4c87-483e-49c6-943f-11ee8f60df85", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "ac43eb11-9045-458f-949c-ec1f04be7cd4", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "f9b2e4a0-cb67-432b-b708-89a6bc2ffd17", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "7daac0d4-226c-463b-8496-8165a2fa0057", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "af92c571-6b2c-4a23-8dfd-7d5c3263eb39", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "ee13382e-b7ed-4283-8696-534bcf306626", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "0d8ea7df-7a8b-428d-b3ad-6e16465a8c2e", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(5357) });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "0916aac0-e3ac-4524-93e0-f58909bac73d", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(8358), "Free" },
                    { 2, "65982ce5-5999-4629-ab80-e37651745f86", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(8380), "Basico" }
                });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "e34675ad-98ea-4c21-b03f-83c0f4877b79", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(7906) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "f7b182fa-182b-45d9-b0de-91d3c2ad03bc", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "7f4a1cdd-e8c2-486c-a8c4-ae0d304a2d42", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(8187) });

            migrationBuilder.InsertData(
                table: "Precios",
                columns: new[] { "Id", "ExternalId", "FechaDeCreacion", "PlanRef", "Tipo", "ValidoDesde", "ValidoHasta", "Valor" },
                values: new object[] { 1, "a88efb7e-1eb9-4c27-b780-df1feb7dc8f3", new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(8449), 1, 0, new DateTime(2023, 8, 30, 21, 49, 6, 61, DateTimeKind.Local).AddTicks(8503), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m });

            migrationBuilder.CreateIndex(
                name: "IX_Precios_PlanRef",
                table: "Precios",
                column: "PlanRef");

            migrationBuilder.CreateIndex(
                name: "IX_Subscripciones_PrecioRef",
                table: "Subscripciones",
                column: "PrecioRef");

            migrationBuilder.CreateIndex(
                name: "IX_Subscripciones_UserRef",
                table: "Subscripciones",
                column: "UserRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscripciones");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "Planes");

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
    }
}
