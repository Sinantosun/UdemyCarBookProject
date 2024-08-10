using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_tagcloud2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCloud_Blogs_BlogID",
                table: "TagCloud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCloud",
                table: "TagCloud");

            migrationBuilder.RenameTable(
                name: "TagCloud",
                newName: "TagClouds");

            migrationBuilder.RenameIndex(
                name: "IX_TagCloud_BlogID",
                table: "TagClouds",
                newName: "IX_TagClouds_BlogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagClouds",
                table: "TagClouds",
                column: "TagCloudID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagClouds_Blogs_BlogID",
                table: "TagClouds",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagClouds_Blogs_BlogID",
                table: "TagClouds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagClouds",
                table: "TagClouds");

            migrationBuilder.RenameTable(
                name: "TagClouds",
                newName: "TagCloud");

            migrationBuilder.RenameIndex(
                name: "IX_TagClouds_BlogID",
                table: "TagCloud",
                newName: "IX_TagCloud_BlogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCloud",
                table: "TagCloud",
                column: "TagCloudID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCloud_Blogs_BlogID",
                table: "TagCloud",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
