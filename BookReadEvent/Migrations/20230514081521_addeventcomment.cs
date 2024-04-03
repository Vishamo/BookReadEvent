using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReadEvent.Migrations
{
    public partial class addeventcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    location = table.Column<string>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    eventType = table.Column<string>(nullable: true),
                    duration = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    otherdetails = table.Column<string>(maxLength: 500, nullable: true),
                    invite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eventid = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    _eventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_CreateEvents__eventId",
                        column: x => x._eventId,
                        principalTable: "CreateEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments__eventId",
                table: "comments",
                column: "_eventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "CreateEvents");
        }
    }
}
