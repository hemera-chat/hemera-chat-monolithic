using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hemera.Chat.EFCore.Migrations
{
    public partial class AddProfileAvatarPathToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "ProfileAvatarPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileAvatarPath",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TransferType",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
