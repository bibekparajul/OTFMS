using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTrafficWeb.Migrations
{
    public partial class addFineHeaderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FineStatus",
                table: "FineHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FineStatus",
                table: "FineHeaders");
        }
    }
}
