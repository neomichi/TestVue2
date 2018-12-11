using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VuetifySpa.Data.Migrations
{
    public partial class AddTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityMpg = table.Column<int>(nullable: false),
                    Classification = table.Column<string>(maxLength: 200, nullable: true),
                    Driveline = table.Column<string>(maxLength: 200, nullable: true),
                    EngineType = table.Column<string>(maxLength: 200, nullable: true),
                    FuelType = table.Column<string>(maxLength: 200, nullable: true),
                    Height = table.Column<int>(nullable: false),
                    HighwayMpg = table.Column<int>(nullable: false),
                    HiHorsepower = table.Column<int>(nullable: false),
                    Hybrid = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 200, nullable: true),
                    ModelYear = table.Column<int>(nullable: false),
                    NumberofForwardGears = table.Column<int>(nullable: false),
                    Torque = table.Column<int>(nullable: false),
                    Transmission = table.Column<string>(maxLength: 200, nullable: true),
                    Width = table.Column<string>(maxLength: 200, nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
