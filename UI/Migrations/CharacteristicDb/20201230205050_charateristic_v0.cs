using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations.CharacteristicDb
{
    public partial class charateristic_v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_BreedCharacteristics_MeasurementUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_SpecieCharacteristics_MeasurementUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedCharacteristicId = table.Column<int>(type: "int", nullable: false),
                    SelectedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristicValues_BreedCharacteristics_BreedCharacteristicId",
                        column: x => x.BreedCharacteristicId,
                        principalTable: "BreedCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecieCharacteristicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieCharacteristicId = table.Column<int>(type: "int", nullable: false),
                    SelectedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieCharacteristicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieCharacteristicValues_SpecieCharacteristics_SpecieCharacteristicId",
                        column: x => x.SpecieCharacteristicId,
                        principalTable: "SpecieCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristics_UnitId",
                table: "BreedCharacteristics",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristicValues_BreedCharacteristicId",
                table: "BreedCharacteristicValues",
                column: "BreedCharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristics_UnitId",
                table: "SpecieCharacteristics",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieCharacteristicValues_SpecieCharacteristicId",
                table: "SpecieCharacteristicValues",
                column: "SpecieCharacteristicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedCharacteristicValues");

            migrationBuilder.DropTable(
                name: "SpecieCharacteristicValues");

            migrationBuilder.DropTable(
                name: "BreedCharacteristics");

            migrationBuilder.DropTable(
                name: "SpecieCharacteristics");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");
        }
    }
}
