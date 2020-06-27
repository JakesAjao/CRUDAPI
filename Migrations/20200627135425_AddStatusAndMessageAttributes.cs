using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular7CRUDAPI.Migrations
{
    public partial class AddStatusAndMessageAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");
        }
    }
}
