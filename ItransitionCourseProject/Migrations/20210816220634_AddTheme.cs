using Microsoft.EntityFrameworkCore.Migrations;

namespace ItransitionCourseProject.Migrations
{
    public partial class AddTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionThemes_ThemeId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Collections",
                newName: "CollectionThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Collections_ThemeId",
                table: "Collections",
                newName: "IX_Collections_CollectionThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionThemes_CollectionThemeId",
                table: "Collections",
                column: "CollectionThemeId",
                principalTable: "CollectionThemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionThemes_CollectionThemeId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "CollectionThemeId",
                table: "Collections",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Collections_CollectionThemeId",
                table: "Collections",
                newName: "IX_Collections_ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionThemes_ThemeId",
                table: "Collections",
                column: "ThemeId",
                principalTable: "CollectionThemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
