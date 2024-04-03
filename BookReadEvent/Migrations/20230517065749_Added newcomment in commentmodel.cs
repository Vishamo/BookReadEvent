using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReadEvent.Migrations
{
    public partial class Addednewcommentincommentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "newcomment",
                table: "comments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newcomment",
                table: "comments");
        }
    }
}
