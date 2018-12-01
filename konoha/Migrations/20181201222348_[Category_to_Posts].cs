using Microsoft.EntityFrameworkCore.Migrations;

namespace konoha.Migrations
{
    public partial class Category_to_Posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Post",
                newName: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryID",
                table: "Post",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_CategoryID",
                table: "Post",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_CategoryID",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_CategoryID",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Post",
                newName: "Category");
        }
    }
}
