using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class makeCalvingNullableForAnimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calvings_Reproductions_ReproductionId",
                table: "Calvings");

            migrationBuilder.DropIndex(
                name: "IX_Calvings_ReproductionId",
                table: "Calvings");

            migrationBuilder.AddColumn<int>(
                name: "CalivingId",
                table: "YoungAnimals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCalvingId",
                table: "YoungAnimals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalivingId",
                table: "males",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCalvingId",
                table: "males",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalivingId",
                table: "Females",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCalvingId",
                table: "Females",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReproductionId",
                table: "Calvings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YoungAnimals_FromCalvingId",
                table: "YoungAnimals",
                column: "FromCalvingId");

            migrationBuilder.CreateIndex(
                name: "IX_males_FromCalvingId",
                table: "males",
                column: "FromCalvingId");

            migrationBuilder.CreateIndex(
                name: "IX_Females_FromCalvingId",
                table: "Females",
                column: "FromCalvingId");

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_ReproductionId",
                table: "Calvings",
                column: "ReproductionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calvings_Reproductions_ReproductionId",
                table: "Calvings",
                column: "ReproductionId",
                principalTable: "Reproductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Females_Calvings_FromCalvingId",
                table: "Females",
                column: "FromCalvingId",
                principalTable: "Calvings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_males_Calvings_FromCalvingId",
                table: "males",
                column: "FromCalvingId",
                principalTable: "Calvings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YoungAnimals_Calvings_FromCalvingId",
                table: "YoungAnimals",
                column: "FromCalvingId",
                principalTable: "Calvings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calvings_Reproductions_ReproductionId",
                table: "Calvings");

            migrationBuilder.DropForeignKey(
                name: "FK_Females_Calvings_FromCalvingId",
                table: "Females");

            migrationBuilder.DropForeignKey(
                name: "FK_males_Calvings_FromCalvingId",
                table: "males");

            migrationBuilder.DropForeignKey(
                name: "FK_YoungAnimals_Calvings_FromCalvingId",
                table: "YoungAnimals");

            migrationBuilder.DropIndex(
                name: "IX_YoungAnimals_FromCalvingId",
                table: "YoungAnimals");

            migrationBuilder.DropIndex(
                name: "IX_males_FromCalvingId",
                table: "males");

            migrationBuilder.DropIndex(
                name: "IX_Females_FromCalvingId",
                table: "Females");

            migrationBuilder.DropIndex(
                name: "IX_Calvings_ReproductionId",
                table: "Calvings");

            migrationBuilder.DropColumn(
                name: "CalivingId",
                table: "YoungAnimals");

            migrationBuilder.DropColumn(
                name: "FromCalvingId",
                table: "YoungAnimals");

            migrationBuilder.DropColumn(
                name: "CalivingId",
                table: "males");

            migrationBuilder.DropColumn(
                name: "FromCalvingId",
                table: "males");

            migrationBuilder.DropColumn(
                name: "CalivingId",
                table: "Females");

            migrationBuilder.DropColumn(
                name: "FromCalvingId",
                table: "Females");

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

            migrationBuilder.AlterColumn<int>(
                name: "ReproductionId",
                table: "Calvings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_ReproductionId",
                table: "Calvings",
                column: "ReproductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calvings_Reproductions_ReproductionId",
                table: "Calvings",
                column: "ReproductionId",
                principalTable: "Reproductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
