using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTrafficWeb.Migrations
{
    public partial class addFineModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FineModels",
                newName: "VehicleNumber");

            migrationBuilder.RenameColumn(
                name: "FineStatus",
                table: "FineModels",
                newName: "LicenseNumber");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "FineModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FineId",
                table: "FineModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FineType",
                table: "FineModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FineModels_DriverId",
                table: "FineModels",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_FineModels_UserModel_DriverId",
                table: "FineModels",
                column: "DriverId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FineModels_UserModel_DriverId",
                table: "FineModels");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_FineModels_DriverId",
                table: "FineModels");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "FineModels");

            migrationBuilder.DropColumn(
                name: "FineId",
                table: "FineModels");

            migrationBuilder.DropColumn(
                name: "FineType",
                table: "FineModels");

            migrationBuilder.RenameColumn(
                name: "VehicleNumber",
                table: "FineModels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LicenseNumber",
                table: "FineModels",
                newName: "FineStatus");
        }
    }
}
