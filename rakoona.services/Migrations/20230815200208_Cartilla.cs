using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.services.Migrations
{
    /// <inheritdoc />
    public partial class Cartilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Macotas_MascotaRef",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacunaciones_Macotas_MascotaRef",
                table: "Vacunaciones");

            migrationBuilder.RenameColumn(
                name: "MascotaRef",
                table: "Vacunaciones",
                newName: "CartillaRef");

            migrationBuilder.RenameIndex(
                name: "IX_Vacunaciones_MascotaRef",
                table: "Vacunaciones",
                newName: "IX_Vacunaciones_CartillaRef");

            migrationBuilder.RenameColumn(
                name: "MascotaRef",
                table: "Consultas",
                newName: "CartillaRef");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_MascotaRef",
                table: "Consultas",
                newName: "IX_Consultas_CartillaRef");

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

            migrationBuilder.CreateIndex(
                name: "IX_Cartillas_MascotaRef",
                table: "Cartillas",
                column: "MascotaRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Cartillas_CartillaRef",
                table: "Consultas",
                column: "CartillaRef",
                principalTable: "Cartillas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacunaciones_Cartillas_CartillaRef",
                table: "Vacunaciones",
                column: "CartillaRef",
                principalTable: "Cartillas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Cartillas_CartillaRef",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacunaciones_Cartillas_CartillaRef",
                table: "Vacunaciones");

            migrationBuilder.DropTable(
                name: "Cartillas");

            migrationBuilder.RenameColumn(
                name: "CartillaRef",
                table: "Vacunaciones",
                newName: "MascotaRef");

            migrationBuilder.RenameIndex(
                name: "IX_Vacunaciones_CartillaRef",
                table: "Vacunaciones",
                newName: "IX_Vacunaciones_MascotaRef");

            migrationBuilder.RenameColumn(
                name: "CartillaRef",
                table: "Consultas",
                newName: "MascotaRef");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_CartillaRef",
                table: "Consultas",
                newName: "IX_Consultas_MascotaRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Macotas_MascotaRef",
                table: "Consultas",
                column: "MascotaRef",
                principalTable: "Macotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacunaciones_Macotas_MascotaRef",
                table: "Vacunaciones",
                column: "MascotaRef",
                principalTable: "Macotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
