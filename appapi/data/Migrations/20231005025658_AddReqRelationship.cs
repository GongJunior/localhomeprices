using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.data.Migrations
{
    /// <inheritdoc />
    public partial class AddReqRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HousingDetails_RequestEventId",
                table: "HousingDetails",
                column: "RequestEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_HousingDetails_RequestEvents_RequestEventId",
                table: "HousingDetails",
                column: "RequestEventId",
                principalTable: "RequestEvents",
                principalColumn: "RequestEventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HousingDetails_RequestEvents_RequestEventId",
                table: "HousingDetails");

            migrationBuilder.DropIndex(
                name: "IX_HousingDetails_RequestEventId",
                table: "HousingDetails");
        }
    }
}
