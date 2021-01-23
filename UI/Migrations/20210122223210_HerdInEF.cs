using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class HerdInEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Herd_HerdId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Herd_Specie_SpecieId",
                table: "Herd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Herd",
                table: "Herd");

            migrationBuilder.RenameTable(
                name: "Herd",
                newName: "Herds");

            migrationBuilder.RenameIndex(
                name: "IX_Herd_SpecieId",
                table: "Herds",
                newName: "IX_Herds_SpecieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Herds",
                table: "Herds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Herds_HerdId",
                table: "Animals",
                column: "HerdId",
                principalTable: "Herds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Herds_Specie_SpecieId",
                table: "Herds",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Herds_HerdId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Herds_Specie_SpecieId",
                table: "Herds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Herds",
                table: "Herds");

            migrationBuilder.RenameTable(
                name: "Herds",
                newName: "Herd");

            migrationBuilder.RenameIndex(
                name: "IX_Herds_SpecieId",
                table: "Herd",
                newName: "IX_Herd_SpecieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Herd",
                table: "Herd",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Herd_HerdId",
                table: "Animals",
                column: "HerdId",
                principalTable: "Herd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Herd_Specie_SpecieId",
                table: "Herd",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
