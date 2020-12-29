using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class characteristic_V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedCharacteristic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristic_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristicValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FemaleId = table.Column<int>(type: "int", nullable: true),
                    MaleId = table.Column<int>(type: "int", nullable: true),
                    YoungAnimalId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristicValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValue_Females_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Females",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValue_males_MaleId",
                        column: x => x.MaleId,
                        principalTable: "males",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValue_YoungAnimals_YoungAnimalId",
                        column: x => x.YoungAnimalId,
                        principalTable: "YoungAnimals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristic_Specie_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Specie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristicValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FemaleId = table.Column<int>(type: "int", nullable: true),
                    MaleId = table.Column<int>(type: "int", nullable: true),
                    YoungAnimalId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristicValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValue_Females_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Females",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValue_males_MaleId",
                        column: x => x.MaleId,
                        principalTable: "males",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValue_YoungAnimals_YoungAnimalId",
                        column: x => x.YoungAnimalId,
                        principalTable: "YoungAnimals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristic_BreedId",
                table: "BreedCharacteristic",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristicValue_FemaleId",
                table: "BreedCharacteristicValue",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristicValue_MaleId",
                table: "BreedCharacteristicValue",
                column: "MaleId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristicValue_YoungAnimalId",
                table: "BreedCharacteristicValue",
                column: "YoungAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristic_SpecieId",
                table: "SpecieCharacteristic",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristicValue_FemaleId",
                table: "SpecieCharacteristicValue",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristicValue_MaleId",
                table: "SpecieCharacteristicValue",
                column: "MaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristicValue_YoungAnimalId",
                table: "SpecieCharacteristicValue",
                column: "YoungAnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedCharacteristic");

            migrationBuilder.DropTable(
                name: "BreedCharacteristicValue");

            migrationBuilder.DropTable(
                name: "SpecieCharacteristic");

            migrationBuilder.DropTable(
                name: "SpecieCharacteristicValue");
        }
    }
}
