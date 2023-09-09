using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.core.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClasesDeAnimales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "6cc0b3ea-ce29-41ae-bcd4-52005bb5f009", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "ce8770dc-f4d2-4101-9bd2-be359d86bc2b", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "42d33ca1-d474-407e-9d3a-e39f4fd78651", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(624) });

            migrationBuilder.UpdateData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "8df48dfd-129b-4437-a8c2-d0b43e47946c", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "54ecb00c-03e9-4900-aa2c-dafc9a89f0ac", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(537) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "5314f937-e525-4355-a431-5b8d7c39ba77", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "3f7dc2aa-0bc7-4b57-95b1-4f7c7a0b05e6", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "373e7269-2d29-4b16-90a7-9cd563f8f946", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "338e688f-c8c7-464c-a593-0c085430269f", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(578) });

            migrationBuilder.UpdateData(
                table: "GeneroAnimal",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "e0684701-0e90-40fe-b5a2-935ae81abb98", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "OrdenAnimal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "c8627a08-0cbb-4bf8-9e7d-70004c7ee466", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "3b45fc68-f97e-4392-bd54-e0aea44041f4", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "f4739456-f95b-4758-bd38-76146a0f477c", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                table: "Precios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion", "ValidoDesde" },
                values: new object[] { "c6f75d1c-3166-4318-9008-b9097dc4b7cd", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(843), new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "91b2fb5c-1c2a-4d7e-8b8a-18c86e1f3cf8", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "d549ffb6-88ae-4f51-8854-ebbe7bbcae04", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(771) });

            migrationBuilder.UpdateData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExternalId", "FechaDeCreacion" },
                values: new object[] { "0823912f-c6c6-48f2-ab87-46534d3057a3", new DateTime(2023, 8, 31, 12, 7, 9, 791, DateTimeKind.Local).AddTicks(786) });
        }
    }
}
