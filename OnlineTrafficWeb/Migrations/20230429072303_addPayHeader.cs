using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTrafficWeb.Migrations
{
    public partial class addPayHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "PaymentHeaders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHeaders_UserModelId",
                table: "PaymentHeaders",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHeaders_UserModel_UserModelId",
                table: "PaymentHeaders",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
