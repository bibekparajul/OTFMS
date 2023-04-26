using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTrafficWeb.Migrations
{
    public partial class backDbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FineModels_TrafficAds_PoliceId",
                table: "FineModels");

            migrationBuilder.DropIndex(
                name: "IX_FineModels_PoliceId",
                table: "FineModels");

            migrationBuilder.DropColumn(
                name: "PoliceId",
                table: "FineModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliceId",
                table: "FineModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FineModels_PoliceId",
                table: "FineModels",
                column: "PoliceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FineModels_TrafficAds_PoliceId",
                table: "FineModels",
                column: "PoliceId",
                principalTable: "TrafficAds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
