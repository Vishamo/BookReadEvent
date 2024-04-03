using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReadEvent.Migrations
{
    public partial class changednameofmodelevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_CreateEvents__eventId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "CreateEvents");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    location = table.Column<string>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    eventType = table.Column<string>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    otherdetails = table.Column<string>(maxLength: 500, nullable: true),
                    invite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Events__eventId",
                table: "comments",
                column: "_eventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Events__eventId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.CreateTable(
                name: "CreateEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    eventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    invite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otherdetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateEvents", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_CreateEvents__eventId",
                table: "comments",
                column: "_eventId",
                principalTable: "CreateEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
