using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildhoodDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ChildhoodDurationInDays = table.Column<int>(type: "int", nullable: false),
                    PregnancyDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    PregnancyDurationInDays = table.Column<int>(type: "int", nullable: false),
                    MinimumTimeSpanBetweenCalvingAndHeat = table.Column<TimeSpan>(type: "time", nullable: false),
                    MinimumTimeSpanBetweenCalvingAndHeatInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breed_Specie_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Specie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Herd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivingMembersNumber = table.Column<long>(type: "bigint", nullable: false),
                    SpecieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Herd_Specie_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Specie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Females",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_Females", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Females_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Females_Herd_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "males",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_males", x => x.Id);
                    table.ForeignKey(
                        name: "FK_males_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_males_Herd_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoungFemales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_RoungFemales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoungFemales_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoungFemales_Herd_HerdId",
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
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte>(type: "tinyint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Reproductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FemaleId = table.Column<int>(type: "int", nullable: true),
                    MaleId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reproductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reproductions_Females_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Females",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reproductions_males_MaleId",
                        column: x => x.MaleId,
                        principalTable: "males",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calvings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReproductionId = table.Column<int>(type: "int", nullable: true),
                    NumberOfNewborn = table.Column<long>(type: "bigint", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FemaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calvings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calvings_Females_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Females",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calvings_Reproductions_ReproductionId",
                        column: x => x.ReproductionId,
                        principalTable: "Reproductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReproductionStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReproductionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReproductionStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReproductionStates_Reproductions_ReproductionId",
                        column: x => x.ReproductionId,
                        principalTable: "Reproductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breed_SpecieId",
                table: "Breed",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_FemaleId",
                table: "Calvings",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_ReproductionId",
                table: "Calvings",
                column: "ReproductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Females_BreedId",
                table: "Females",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Females_HerdId",
                table: "Females",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_Herd_SpecieId",
                table: "Herd",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_males_BreedId",
                table: "males",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_males_HerdId",
                table: "males",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_Reproductions_FemaleId",
                table: "Reproductions",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reproductions_MaleId",
                table: "Reproductions",
                column: "MaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReproductionStates_ReproductionId",
                table: "ReproductionStates",
                column: "ReproductionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoungFemales_BreedId",
                table: "RoungFemales",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_RoungFemales_HerdId",
                table: "RoungFemales",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calvings");

            migrationBuilder.DropTable(
                name: "ReproductionStates");

            migrationBuilder.DropTable(
                name: "RoungFemales");

            migrationBuilder.DropTable(
                name: "YoungMales");

            migrationBuilder.DropTable(
                name: "Reproductions");

            migrationBuilder.DropTable(
                name: "Females");

            migrationBuilder.DropTable(
                name: "males");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Herd");

            migrationBuilder.DropTable(
                name: "Specie");
        }
    }
}
