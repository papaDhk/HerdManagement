using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    MeasurementUnitCategory = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    Symbol = table.Column<string>(type: "TEXT", nullable: true),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    ChildhoodDurationInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    PregnancyDurationInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    MinimumTimeSpanBetweenCalvingAndHeatInDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    SpecieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Herds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    LivingMembersNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    SpecieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Herds_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecieId = table.Column<int>(type: "INTEGER", nullable: true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true),
                    ValueList = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristics_MeasurementUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristics_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreedId = table.Column<int>(type: "INTEGER", nullable: true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true),
                    ValueList = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristics_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedCharacteristics_MeasurementUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Picture = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Origin = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<uint>(type: "INTEGER", nullable: false),
                    PresenceStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BreedId = table.Column<int>(type: "INTEGER", nullable: false),
                    HerdId = table.Column<int>(type: "INTEGER", nullable: false),
                    category_type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Herds_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalFeedings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFeedings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalFeedings_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalFeedings_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalFeedings_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreedCharacteristicId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true),
                    SelectedValue = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValues_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValues_BreedCharacteristics_BreedCharacteristicId",
                        column: x => x.BreedCharacteristicId,
                        principalTable: "BreedCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reproductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FemaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reproductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reproductions_Animals_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reproductions_Animals_MaleId",
                        column: x => x.MaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecieCharacteristicId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true),
                    SelectedValue = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValues_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValues_SpecieCharacteristics_SpecieCharacteristicId",
                        column: x => x.SpecieCharacteristicId,
                        principalTable: "SpecieCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weighings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weighings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weighings_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weighings_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calvings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true),
                    ReproductionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    FemaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calvings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calvings_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calvings_Animals_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calvings_Reproductions_ReproductionId",
                        column: x => x.ReproductionId,
                        principalTable: "Reproductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReproductionStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReproductionId = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReproductionStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReproductionStates_Reproductions_ReproductionId",
                        column: x => x.ReproductionId,
                        principalTable: "Reproductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFeedings_AnimalId",
                table: "AnimalFeedings",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFeedings_FoodId",
                table: "AnimalFeedings",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFeedings_MeasurementUnitId",
                table: "AnimalFeedings",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_BreedId",
                table: "Animals",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_HerdId",
                table: "Animals",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristics_BreedId",
                table: "BreedCharacteristics",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristics_UnitId",
                table: "BreedCharacteristics",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristicValues_AnimalId",
                table: "BreedCharacteristicValues",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristicValues_BreedCharacteristicId",
                table: "BreedCharacteristicValues",
                column: "BreedCharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_SpecieId",
                table: "Breeds",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_AnimalId",
                table: "Calvings",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_FemaleId",
                table: "Calvings",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Calvings_ReproductionId",
                table: "Calvings",
                column: "ReproductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Herds_SpecieId",
                table: "Herds",
                column: "SpecieId");

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
                name: "IX_SpecieCharacteristics_SpecieId",
                table: "SpecieCharacteristics",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristics_UnitId",
                table: "SpecieCharacteristics",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristicValues_AnimalId",
                table: "SpecieCharacteristicValues",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristicValues_SpecieCharacteristicId",
                table: "SpecieCharacteristicValues",
                column: "SpecieCharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_Weighings_AnimalId",
                table: "Weighings",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Weighings_MeasurementUnitId",
                table: "Weighings",
                column: "MeasurementUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalFeedings");

            migrationBuilder.DropTable(
                name: "BreedCharacteristicValues");

            migrationBuilder.DropTable(
                name: "Calvings");

            migrationBuilder.DropTable(
                name: "ReproductionStates");

            migrationBuilder.DropTable(
                name: "SpecieCharacteristicValues");

            migrationBuilder.DropTable(
                name: "Weighings");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "BreedCharacteristics");

            migrationBuilder.DropTable(
                name: "Reproductions");

            migrationBuilder.DropTable(
                name: "SpecieCharacteristics");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Herds");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
