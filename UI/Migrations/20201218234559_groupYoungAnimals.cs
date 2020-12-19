using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class groupYoungAnimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YoungFemales");

            migrationBuilder.DropTable(
                name: "YoungMales");

            migrationBuilder.CreateTable(
                name: "YoungAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Bought = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    PresenceStatus = table.Column<int>(type: "int", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    HerdId = table.Column<int>(type: "int", nullable: true),
                    BreedCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecieCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoungAnimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YoungAnimals_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoungAnimals_Herd_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YoungAnimals_BreedId",
                table: "YoungAnimals",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_YoungAnimals_HerdId",
                table: "YoungAnimals",
                column: "HerdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YoungAnimals");

            migrationBuilder.CreateTable(
                name: "YoungFemales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bought = table.Column<bool>(type: "bit", nullable: false),
                    BreedCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HerdId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PresenceStatus = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    SpecieCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoungFemales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YoungFemales_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoungFemales_Herd_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YoungMales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bought = table.Column<bool>(type: "bit", nullable: false),
                    BreedCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HerdId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PresenceStatus = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    SpecieCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoungMales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YoungMales_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoungMales_Herd_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YoungFemales_BreedId",
                table: "YoungFemales",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_YoungFemales_HerdId",
                table: "YoungFemales",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_YoungMales_BreedId",
                table: "YoungMales",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_YoungMales_HerdId",
                table: "YoungMales",
                column: "HerdId");
        }
    }
}
