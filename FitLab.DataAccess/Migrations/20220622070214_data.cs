using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitLab.DataAccess.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subscriptions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subscriptions");
        }
    }
}
