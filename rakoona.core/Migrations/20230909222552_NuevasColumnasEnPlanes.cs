using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.core.Migrations
{
    /// <inheritdoc />
    public partial class NuevasColumnasEnPlanes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroDeClinicas",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroDeMedicos",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "bc264a88-0f30-4ee7-a8dc-1f8bf4b3dd5a", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(2961) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "4c8ae28f-fb09-46b2-80ca-cf32131f3037", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "1aa06ea5-821f-4c6e-b257-6de29f6f2999", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3068) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "6da8fa50-6174-4c2e-93e2-6b26dcd951a3", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3085) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "7cc936c6-e126-4cd9-8345-8531c9942097", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(2984) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "d2433abd-c0e3-4173-9b08-6adc3c4917b8", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(2988) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "16326c1c-07e9-4188-b022-e21c48162f00", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(2991) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "bbdca1d6-617a-4b9c-89b1-e6d5b1f78876", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "f14ea7a3-3163-48ad-9bcf-c9a0df957fcf", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3026) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "d4aee136-c4f4-4b77-af91-a4199b1634ce", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3033) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "8f050351-70df-4ee2-bd27-bfa2813e43f7", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion", "NumeroDeClinicas", "NumeroDeMedicos" },
                values: new object[] { "4b122ffa-7bde-4606-b926-eadbdef1f0dc", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3226), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion", "NumeroDeClinicas", "NumeroDeMedicos" },
                values: new object[] { "b0ebbee0-92f1-4737-addd-ee9758d6c413", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3234), 1, 5 });

            migrationBuilder.UpdateData(
                table: "Precios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion", "ValidoDesde" },
                values: new object[] { "5b1fdb67-1398-4a4f-b2ae-0f59562fd287", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3248), new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "57e45a7a-c42b-4a6b-84e8-667ed56b4a40", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3113) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "02a1136e-8a7b-43c4-86b3-36ff98c3fd5f", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3175) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "a205045b-71cb-4eae-b2b2-47339a79af45", new DateTime(2023, 9, 9, 16, 25, 52, 113, DateTimeKind.Local).AddTicks(3192) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDeClinicas",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "NumeroDeMedicos",
                table: "Planes");

            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "910d0a64-4f7d-4439-919f-ed638edca03e", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "1d33effd-c1c4-4d73-b65f-31ce7e612858", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "629031ec-8c34-40ea-b480-fe618e36cbfe", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "877c15d5-5d7e-4d54-b972-6b9b765cb742", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(563) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "866f223a-3822-4292-ad71-673395799971", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "1817ffa6-878d-4726-a6a5-94cde59ef9f2", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "a4e50629-3fe0-4791-b8ef-8be94989f8b5", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "b413c4de-2a90-4753-ae4b-b24b5c11dbf7", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "5f5fe999-22a0-4946-9c5e-e1cf56c93dd9", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(493) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "0cc5d86e-aeb6-4c70-990e-45b794edaca3", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "9bc8b950-eb12-4b07-9dc2-a3e8cf50dee3", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(233) });

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "8cf96be2-c283-4fc4-b3e1-a6d39a1a3c22", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "2f518ffd-06d1-4ffe-b752-2f8680463fbf", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "Precios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion", "ValidoDesde" },
                values: new object[] { "7bdb2fdb-4823-4f22-8046-31bfe1a84b6e", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(722), new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(733) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "87503a59-1091-4ca9-a404-4037433342f9", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "093a7558-b8c5-490f-9a88-b896a4c714c5", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "3f150bef-5a73-440d-b37b-10a5ef7535f4", new DateTime(2023, 9, 9, 15, 58, 15, 518, DateTimeKind.Local).AddTicks(669) });
        }
    }
}
