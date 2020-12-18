using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class RenameYoungFemalesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoungFemales_Breed_BreedId",
                table: "RoungFemales");

            migrationBuilder.DropForeignKey(
                name: "FK_RoungFemales_Herd_HerdId",
                table: "RoungFemales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoungFemales",
                table: "RoungFemales");

            migrationBuilder.RenameTable(
                name: "RoungFemales",
                newName: "YoungFemales");

            migrationBuilder.RenameIndex(
                name: "IX_RoungFemales_HerdId",
                table: "YoungFemales",
                newName: "IX_YoungFemales_HerdId");

            migrationBuilder.RenameIndex(
                name: "IX_RoungFemales_BreedId",
                table: "YoungFemales",
                newName: "IX_YoungFemales_BreedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YoungFemales",
                table: "YoungFemales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_YoungFemales_Breed_BreedId",
                table: "YoungFemales",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YoungFemales_Herd_HerdId",
                table: "YoungFemales",
                column: "HerdId",
                principalTable: "Herd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YoungFemales_Breed_BreedId",
                table: "YoungFemales");

            migrationBuilder.DropForeignKey(
                name: "FK_YoungFemales_Herd_HerdId",
                table: "YoungFemales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YoungFemales",
                table: "YoungFemales");

            migrationBuilder.RenameTable(
                name: "YoungFemales",
                newName: "RoungFemales");

            migrationBuilder.RenameIndex(
                name: "IX_YoungFemales_HerdId",
                table: "RoungFemales",
                newName: "IX_RoungFemales_HerdId");

            migrationBuilder.RenameIndex(
                name: "IX_YoungFemales_BreedId",
                table: "RoungFemales",
                newName: "IX_RoungFemales_BreedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoungFemales",
                table: "RoungFemales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoungFemales_Breed_BreedId",
                table: "RoungFemales",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoungFemales_Herd_HerdId",
                table: "RoungFemales",
                column: "HerdId",
                principalTable: "Herd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
