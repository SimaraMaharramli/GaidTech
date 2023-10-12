using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAgency.Migrations
{
    public partial class dbsettranslate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutTranslate_Abouts_AboutId",
                table: "AboutTranslate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutTranslate",
                table: "AboutTranslate");

            migrationBuilder.RenameTable(
                name: "AboutTranslate",
                newName: "AboutTranslates");

            migrationBuilder.RenameIndex(
                name: "IX_AboutTranslate_AboutId",
                table: "AboutTranslates",
                newName: "IX_AboutTranslates_AboutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutTranslates",
                table: "AboutTranslates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutTranslates_Abouts_AboutId",
                table: "AboutTranslates",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutTranslates_Abouts_AboutId",
                table: "AboutTranslates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutTranslates",
                table: "AboutTranslates");

            migrationBuilder.RenameTable(
                name: "AboutTranslates",
                newName: "AboutTranslate");

            migrationBuilder.RenameIndex(
                name: "IX_AboutTranslates_AboutId",
                table: "AboutTranslate",
                newName: "IX_AboutTranslate_AboutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutTranslate",
                table: "AboutTranslate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutTranslate_Abouts_AboutId",
                table: "AboutTranslate",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
