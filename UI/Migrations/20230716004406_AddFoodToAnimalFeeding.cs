using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    public partial class AddFoodToAnimalFeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "AnimalFeedings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFeedings_FoodId",
                table: "AnimalFeedings",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalFeedings_Foods_FoodId",
                table: "AnimalFeedings",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalFeedings_Foods_FoodId",
                table: "AnimalFeedings");

            migrationBuilder.DropIndex(
                name: "IX_AnimalFeedings_FoodId",
                table: "AnimalFeedings");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "AnimalFeedings");
        }
    }
}
