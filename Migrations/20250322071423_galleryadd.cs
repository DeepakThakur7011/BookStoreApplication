using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    /// <inheritdoc />
    public partial class galleryadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_BooksId",
                table: "BookGallery");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookGallery",
                newName: "booksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_BooksId",
                table: "BookGallery",
                newName: "IX_BookGallery_booksId");

            migrationBuilder.AlterColumn<int>(
                name: "booksId",
                table: "BookGallery",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_booksId",
                table: "BookGallery",
                column: "booksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_booksId",
                table: "BookGallery");

            migrationBuilder.RenameColumn(
                name: "booksId",
                table: "BookGallery",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_booksId",
                table: "BookGallery",
                newName: "IX_BookGallery_BooksId");

            migrationBuilder.AlterColumn<int>(
                name: "BooksId",
                table: "BookGallery",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_BooksId",
                table: "BookGallery",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
