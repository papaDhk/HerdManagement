using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class renameanimal_calvingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalivingId",
                table: "YoungAnimals");

            migrationBuilder.DropColumn(
                name: "CalivingId",
                table: "males");

            migrationBuilder.DropColumn(
                name: "CalivingId",
                table: "Females");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalivingId",
                table: "YoungAnimals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalivingId",
                table: "males",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalivingId",
                table: "Females",
                type: "int",
                nullable: true);
        }
    }
}
