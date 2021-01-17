using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class IntroduceMeaurementUnitsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weighings_MeasurementUnit_MeasurementUnitId",
                table: "Weighings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnit",
                table: "MeasurementUnit");

            migrationBuilder.RenameTable(
                name: "MeasurementUnit",
                newName: "MeasurementUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnits",
                table: "MeasurementUnits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weighings_MeasurementUnits_MeasurementUnitId",
                table: "Weighings",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weighings_MeasurementUnits_MeasurementUnitId",
                table: "Weighings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnits",
                table: "MeasurementUnits");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                newName: "MeasurementUnit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnit",
                table: "MeasurementUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weighings_MeasurementUnit_MeasurementUnitId",
                table: "Weighings",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
