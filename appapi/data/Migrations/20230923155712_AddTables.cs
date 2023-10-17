using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.data.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HousingDetails",
                columns: table => new
                {
                    HousingDetailID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestEventId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bathrooms = table.Column<int>(type: "INTEGER", nullable: true),
                    Bedrooms = table.Column<int>(type: "INTEGER", nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    HomeStatus = table.Column<string>(type: "TEXT", nullable: true),
                    HomeType = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    LivingArea = table.Column<int>(type: "INTEGER", nullable: true),
                    LotAreaUnit = table.Column<string>(type: "TEXT", nullable: true),
                    LotAreaValue = table.Column<double>(type: "REAL", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: true),
                    RentEstimate = table.Column<int>(type: "INTEGER", nullable: true),
                    Zestimate = table.Column<int>(type: "INTEGER", nullable: true),
                    TaxAssessedValue = table.Column<int>(type: "INTEGER", nullable: true),
                    ImgLink = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingDetails", x => x.HousingDetailID);
                });

            migrationBuilder.CreateTable(
                name: "RequestEvents",
                columns: table => new
                {
                    RequestEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestUri = table.Column<string>(type: "TEXT", nullable: false),
                    RequestGroupHash = table.Column<string>(type: "TEXT", nullable: false),
                    RequestTimeUTC = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Success = table.Column<bool>(type: "INTEGER", nullable: false),
                    ErrorMessage = table.Column<string>(type: "TEXT", nullable: true),
                    RequestEnvironment = table.Column<string>(type: "TEXT", nullable: false),
                    ExpectedTotalResults = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualTotalResults = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestEvents", x => x.RequestEventId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HousingDetails");

            migrationBuilder.DropTable(
                name: "RequestEvents");
        }
    }
}
