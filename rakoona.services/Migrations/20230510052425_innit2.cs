using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.services.Migrations
{
    /// <inheritdoc />
    public partial class innit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prueba",
                table: "Macotas",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prueba",
                table: "Macotas");
        }
    }
}
