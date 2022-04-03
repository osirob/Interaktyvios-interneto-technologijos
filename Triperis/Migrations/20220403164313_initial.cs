using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Triperis.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metai = table.Column<int>(type: "int", nullable: false),
                    KuroTipas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KebuloTipas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariklioTuris = table.Column<double>(type: "float", nullable: false),
                    Galia = table.Column<int>(type: "int", nullable: false),
                    Rida = table.Column<int>(type: "int", nullable: false),
                    Defektai = table.Column<bool>(type: "bit", nullable: false),
                    Spalva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PavaruDeze = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aprasymas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parduotas = table.Column<bool>(type: "bit", nullable: false),
                    Kaina = table.Column<int>(type: "int", nullable: false),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
