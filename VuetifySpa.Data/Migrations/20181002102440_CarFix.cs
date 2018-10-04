using Microsoft.EntityFrameworkCore.Migrations;

namespace VuetifySpa.Data.Migrations
{
    public partial class CarFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "Cars",
                newName: "Img");

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Cars",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Cars",
                newName: "Avatar");
        }
    }
}
