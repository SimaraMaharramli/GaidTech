using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAgency.Migrations
{
    public partial class servicemodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingsTranslates_Settings_SettingId",
                table: "SettingsTranslates");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "SettingId",
                table: "SettingsTranslates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "SettingsTranslates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ServiceTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTranslates_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTranslates_ServiceId",
                table: "ServiceTranslates",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsTranslates_Settings_SettingId",
                table: "SettingsTranslates",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingsTranslates_Settings_SettingId",
                table: "SettingsTranslates");

            migrationBuilder.DropTable(
                name: "ServiceTranslates");

            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "SettingsTranslates");

            migrationBuilder.AlterColumn<int>(
                name: "SettingId",
                table: "SettingsTranslates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsTranslates_Settings_SettingId",
                table: "SettingsTranslates",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id");
        }
    }
}
