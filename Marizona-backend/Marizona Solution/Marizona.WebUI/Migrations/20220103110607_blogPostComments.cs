using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marizona.WebUI.Migrations
{
    public partial class blogPostComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogPostId = table.Column<long>(type: "bigint", nullable: false),
                    BlogPostId1 = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostComments_BlogPostComments_ParentId1",
                        column: x => x.ParentId1,
                        principalTable: "BlogPostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPostComments_Blogs_BlogPostId1",
                        column: x => x.BlogPostId1,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_BlogPostId1",
                table: "BlogPostComments",
                column: "BlogPostId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_ParentId1",
                table: "BlogPostComments",
                column: "ParentId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostComments");
        }
    }
}
