using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTrafficWeb.Migrations
{
    public partial class changeFineAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FineModels_UserModel_DriverId",
                table: "FineModels");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "FineModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_FineModels_DriversAds_DriverId",
                table: "FineModels",
                column: "DriverId",
                principalTable: "DriversAds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FineModels_DriversAds_DriverId",
                table: "FineModels");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "FineModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FineModels_UserModel_DriverId",
                table: "FineModels",
                column: "DriverId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
