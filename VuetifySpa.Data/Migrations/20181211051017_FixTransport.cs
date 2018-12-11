using Microsoft.EntityFrameworkCore.Migrations;

namespace VuetifySpa.Data.Migrations
{
    public partial class FixTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModelYear",
                table: "Transports",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ModelYear",
                table: "Transports",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
