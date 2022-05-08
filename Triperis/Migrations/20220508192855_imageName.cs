using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Triperis.Migrations
{
    public partial class imageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "Path");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Images",
                newName: "Name");
        }
    }
}
