using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTrafficWeb.Migrations
{
    public partial class changeFineModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrafficId",
                table: "FineModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FineModels_TrafficId",
                table: "FineModels",
                column: "TrafficId");

            migrationBuilder.AddForeignKey(
                name: "FK_FineModels_TrafficAds_TrafficId",
                table: "FineModels",
                column: "TrafficId",
                principalTable: "TrafficAds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FineModels_TrafficAds_TrafficId",
                table: "FineModels");

            migrationBuilder.DropIndex(
                name: "IX_FineModels_TrafficId",
                table: "FineModels");

            migrationBuilder.DropColumn(
                name: "TrafficId",
                table: "FineModels");
        }
    }
}
