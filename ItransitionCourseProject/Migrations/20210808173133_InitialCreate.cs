using Microsoft.EntityFrameworkCore.Migrations;

namespace ItransitionCourseProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionComments");

            migrationBuilder.DropTable(
                name: "CollectionCustomFields");

            migrationBuilder.DropTable(
                name: "CollectionElementTags");

            migrationBuilder.DropTable(
                name: "CollectionLikes");

            migrationBuilder.DropTable(
                name: "CollectionTags");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CollectionComment",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CommentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionComment", x => new { x.CollectionId, x.CommentsId });
                    table.ForeignKey(
                        name: "FK_CollectionComment_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionComment_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionCustomField",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CustomFieldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCustomField", x => new { x.CollectionId, x.CustomFieldsId });
                    table.ForeignKey(
                        name: "FK_CollectionCustomField_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionCustomField_CustomFields_CustomFieldsId",
                        column: x => x.CustomFieldsId,
                        principalTable: "CustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionElementTag",
                columns: table => new
                {
                    CollectionElementsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionElementTag", x => new { x.CollectionElementsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CollectionElementTag_CollectionElements_CollectionElementsId",
                        column: x => x.CollectionElementsId,
                        principalTable: "CollectionElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionElementTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "CollectionTag",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTag", x => new { x.CollectionId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CollectionTag_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionComment_CommentsId",
                table: "CollectionComment",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCustomField_CustomFieldsId",
                table: "CollectionCustomField",
                column: "CustomFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionElementTag_TagsId",
                table: "CollectionElementTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionLike_LikesId",
                table: "CollectionLike",
                column: "LikesId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionTag_TagsId",
                table: "CollectionTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionComment");

            migrationBuilder.DropTable(
                name: "CollectionCustomField");

            migrationBuilder.DropTable(
                name: "CollectionElementTag");

            migrationBuilder.DropTable(
                name: "CollectionLike");

            migrationBuilder.DropTable(
                name: "CollectionTag");

            migrationBuilder.AlterColumn<int>(
                name: "TagName",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CollectionComments",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CommentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionComments", x => new { x.CollectionId, x.CommentsId });
                    table.ForeignKey(
                        name: "FK_CollectionComments_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionComments_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionCustomFields",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CustomFieldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCustomFields", x => new { x.CollectionId, x.CustomFieldsId });
                    table.ForeignKey(
                        name: "FK_CollectionCustomFields_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionCustomFields_CustomFields_CustomFieldsId",
                        column: x => x.CustomFieldsId,
                        principalTable: "CustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionElementTags",
                columns: table => new
                {
                    CollectionElementsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionElementTags", x => new { x.CollectionElementsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CollectionElementTags_CollectionElements_CollectionElementsId",
                        column: x => x.CollectionElementsId,
                        principalTable: "CollectionElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionElementTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionLikes",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    LikesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionLikes", x => new { x.CollectionId, x.LikesId });
                    table.ForeignKey(
                        name: "FK_CollectionLikes_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionLikes_Likes_LikesId",
                        column: x => x.LikesId,
                        principalTable: "Likes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionTags",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTags", x => new { x.CollectionId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CollectionTags_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionComments_CommentsId",
                table: "CollectionComments",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCustomFields_CustomFieldsId",
                table: "CollectionCustomFields",
                column: "CustomFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionElementTags_TagsId",
                table: "CollectionElementTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionLikes_LikesId",
                table: "CollectionLikes",
                column: "LikesId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionTags_TagsId",
                table: "CollectionTags",
                column: "TagsId");
        }
    }
}
