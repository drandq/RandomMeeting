using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomMeeting.Data.Migrations
{
    public partial class AddedRequestedMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestedMeetings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DesiredGender = table.Column<int>(nullable: false),
                    DesiredAgeGroup = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestedMeetings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestedMeetings_UserId",
                table: "RequestedMeetings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestedMeetings");
        }
    }
}
