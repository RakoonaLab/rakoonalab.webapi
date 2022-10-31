using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rakoona.webapi.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Personas");
        }
    }
}
