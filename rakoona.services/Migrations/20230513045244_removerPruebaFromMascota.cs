using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.services.Migrations
{
    /// <inheritdoc />
    public partial class removerPruebaFromMascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prueba",
                table: "Macotas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prueba",
                table: "Macotas",
                type: "int",
                nullable: true);
        }
    }
}
