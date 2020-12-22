using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class AnimalOrigin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reproductions_Females_FemaleId",
                table: "Reproductions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reproductions_males_MaleId",
                table: "Reproductions");

            migrationBuilder.DropForeignKey(
                name: "FK_ReproductionStates_Reproductions_ReproductionId",
                table: "ReproductionStates");

            migrationBuilder.DropColumn(
                name: "Bought",
                table: "YoungAnimals");

            migrationBuilder.DropColumn(
                name: "Bought",
                table: "males");

            migrationBuilder.DropColumn(
                name: "Bought",
                table: "Females");

            migrationBuilder.AddColumn<int>(
                name: "Origin",
                table: "YoungAnimals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReproductionId",
                table: "ReproductionStates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaleId",
                table: "Reproductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FemaleId",
                table: "Reproductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Origin",
                table: "males",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Origin",
                table: "Females",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reproductions_Females_FemaleId",
                table: "Reproductions",
                column: "FemaleId",
                principalTable: "Females",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reproductions_males_MaleId",
                table: "Reproductions",
                column: "MaleId",
                principalTable: "males",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReproductionStates_Reproductions_ReproductionId",
                table: "ReproductionStates",
                column: "ReproductionId",
                principalTable: "Reproductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reproductions_Females_FemaleId",
                table: "Reproductions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reproductions_males_MaleId",
                table: "Reproductions");

            migrationBuilder.DropForeignKey(
                name: "FK_ReproductionStates_Reproductions_ReproductionId",
                table: "ReproductionStates");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "YoungAnimals");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "males");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Females");

            migrationBuilder.AddColumn<bool>(
                name: "Bought",
                table: "YoungAnimals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ReproductionId",
                table: "ReproductionStates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaleId",
                table: "Reproductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FemaleId",
                table: "Reproductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Bought",
                table: "males",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bought",
                table: "Females",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Reproductions_Females_FemaleId",
                table: "Reproductions",
                column: "FemaleId",
                principalTable: "Females",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reproductions_males_MaleId",
                table: "Reproductions",
                column: "MaleId",
                principalTable: "males",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReproductionStates_Reproductions_ReproductionId",
                table: "ReproductionStates",
                column: "ReproductionId",
                principalTable: "Reproductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
