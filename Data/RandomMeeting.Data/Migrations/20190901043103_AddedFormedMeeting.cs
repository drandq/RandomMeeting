using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomMeeting.Data.Migrations
{
    public partial class AddedFormedMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormedMeetings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PictureUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    FirstUserId = table.Column<string>(nullable: true),
                    SecondUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormedMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormedMeetings_AspNetUsers_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormedMeetings_AspNetUsers_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormedMeetings_FirstUserId",
                table: "FormedMeetings",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormedMeetings_SecondUserId",
                table: "FormedMeetings",
                column: "SecondUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormedMeetings");
        }
    }
}
