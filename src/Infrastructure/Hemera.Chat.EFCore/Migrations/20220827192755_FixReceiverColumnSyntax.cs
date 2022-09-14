using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hemera.Chat.EFCore.Migrations
{
    public partial class FixReceiverColumnSyntax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reciever",
                table: "Messages",
                newName: "Receiver");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "Messages",
                newName: "Reciever");
        }
    }
}
