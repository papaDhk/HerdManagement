using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class seeIfThereAreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calvings_Females_FemaleId",
                table: "Calvings");

            migrationBuilder.DropForeignKey(
                name: "FK_Females_Calvings_FromCalvingId",
                table: "Females");

            migrationBuilder.DropForeignKey(
                name: "FK_males_Calvings_FromCalvingId",
                table: "males");

            migrationBuilder.DropIndex(
                name: "IX_males_FromCalvingId",
                table: "males");

            migrationBuilder.DropIndex(
                name: "IX_Females_FromCalvingId",
                table: "Females");

            migrationBuilder.AddColumn<int>(
                name: "FromCalvingId1",
                table: "males",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCalvingId1",
                table: "Females",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FemaleId",
                table: "Calvings",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaleId",
                table: "Calvings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_males_FromCalvingId1",
                table: "males",
                column: "FromCalvingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Females_FromCalvingId1",
                table: "Females",
                column: "FromCalvingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Calvings_Females_FemaleId",
                table: "Calvings",
                column: "FemaleId",
                principalTable: "Females",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Females_Calvings_FromCalvingId1",
                table: "Females",
                column: "FromCalvingId1",
                principalTable: "Calvings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_males_Calvings_FromCalvingId1",
                table: "males",
                column: "FromCalvingId1",
                principalTable: "Calvings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calvings_Females_FemaleId",
                table: "Calvings");

            migrationBuilder.DropForeignKey(
                name: "FK_Females_Calvings_FromCalvingId1",
                table: "Females");

            migrationBuilder.DropForeignKey(
                name: "FK_males_Calvings_FromCalvingId1",
                table: "males");

            migrationBuilder.DropIndex(
                name: "IX_males_FromCalvingId1",
                table: "males");

            migrationBuilder.DropIndex(
                name: "IX_Females_FromCalvingId1",
                table: "Females");

            migrationBuilder.DropColumn(
                name: "FromCalvingId1",
                table: "males");

            migrationBuilder.DropColumn(
                name: "FromCalvingId1",
                table: "Females");

            migrationBuilder.DropColumn(
                name: "MaleId",
                table: "Calvings");

            migrationBuilder.AlterColumn<int>(
                name: "FemaleId",
                table: "Calvings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_males_FromCalvingId",
                table: "males",
                column: "FromCalvingId");

            migrationBuilder.CreateIndex(
                name: "IX_Females_FromCalvingId",
                table: "Females",
                column: "FromCalvingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calvings_Females_FemaleId",
                table: "Calvings",
                column: "FemaleId",
                principalTable: "Females",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
        }
    }
}
