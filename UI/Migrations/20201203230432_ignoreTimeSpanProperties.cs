using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class ignoreTimeSpanProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildhoodDuration",
                table: "Specie");

            migrationBuilder.DropColumn(
                name: "MinimumTimeSpanBetweenCalvingAndHeat",
                table: "Specie");

            migrationBuilder.DropColumn(
                name: "PregnancyDuration",
                table: "Specie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ChildhoodDuration",
                table: "Specie",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MinimumTimeSpanBetweenCalvingAndHeat",
                table: "Specie",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PregnancyDuration",
                table: "Specie",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
