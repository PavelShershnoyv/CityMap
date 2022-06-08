using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractiveMap.Infrastructure.Migrations.Map
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LayerType = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Position_Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Position_Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LayerType = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Position_Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Position_Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMarks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "UserMarks");
        }
    }
}
