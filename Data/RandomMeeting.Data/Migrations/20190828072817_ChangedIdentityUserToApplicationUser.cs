using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomMeeting.Data.Migrations
{
    public partial class ChangedIdentityUserToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "AspNetUsers");
        }
    }
}
