using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAgency.Migrations
{
    public partial class MessafePropAddedToClientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Clients");
        }
    }
}
