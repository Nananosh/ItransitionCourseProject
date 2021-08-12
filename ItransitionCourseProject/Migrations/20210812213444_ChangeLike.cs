using Microsoft.EntityFrameworkCore.Migrations;

namespace ItransitionCourseProject.Migrations
{
    public partial class ChangeLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionLike");

            migrationBuilder.DropColumn(
                name: "Star",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CollectionId",
                table: "Likes",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Collections_CollectionId",
                table: "Likes",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Collections_CollectionId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_CollectionId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CollectionLike",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    LikesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionLike", x => new { x.CollectionId, x.LikesId });
                    table.ForeignKey(
                        name: "FK_CollectionLike_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionLike_Likes_LikesId",
                        column: x => x.LikesId,
                        principalTable: "Likes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionLike_LikesId",
                table: "CollectionLike",
                column: "LikesId");
        }
    }
}
