using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VuetifySpa.Data.Migrations
{
    public partial class FixCar4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateIt",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ShowInMain",
                table: "Cars",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateIt",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ShowInMain",
                table: "Cars");
        }
    }
}
