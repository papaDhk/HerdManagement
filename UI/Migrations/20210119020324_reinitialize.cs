using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class reinitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildhoodDurationInDays = table.Column<int>(type: "int", nullable: false),
                    PregnancyDurationInDays = table.Column<int>(type: "int", nullable: false),
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
                name: "SpecieCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristics_MeasurementUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristics_Specie_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Specie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristics_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristics_MeasurementUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Origin = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    PresenceStatus = table.Column<int>(type: "int", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    HerdId = table.Column<int>(type: "int", nullable: false),
                    category_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Herd_HerdId",
                        column: x => x.HerdId,
                        principalTable: "Herd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedCharacteristicId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    SelectedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValues_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FemaleId = table.Column<int>(type: "int", nullable: false),
                    MaleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reproductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reproductions_Animals_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reproductions_Animals_MaleId",
                        column: x => x.MaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieCharacteristicId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    SelectedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValues_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReproductionId = table.Column<int>(type: "int", nullable: false),
                    MaleId = table.Column<int>(type: "int", nullable: false),
                    FemaleId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calvings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calvings_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Calvings_Animals_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReproductionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_Animals_BreedId",
                table: "Animals",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_HerdId",
                table: "Animals",
                column: "HerdId");

            migrationBuilder.CreateIndex(
                name: "IX_Breed_SpecieId",
                table: "Breed",
                column: "SpecieId");

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
                name: "IX_Herd_SpecieId",
                table: "Herd",
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
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Herd");

            migrationBuilder.DropTable(
                name: "Specie");
        }
    }
}
