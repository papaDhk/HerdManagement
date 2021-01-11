using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class addSimpleTypeToAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Breed_BreedId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Herd_HerdId",
                table: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Breed_BreedId",
                table: "Animals",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Herd_HerdId",
                table: "Animals",
                column: "HerdId",
                principalTable: "Herd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Breed_BreedId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Herd_HerdId",
                table: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Breed_BreedId",
                table: "Animals",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Herd_HerdId",
                table: "Animals",
                column: "HerdId",
                principalTable: "Herd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
