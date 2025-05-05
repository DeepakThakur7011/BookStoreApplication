using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class LanguageIdColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Language",
                newName: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Language",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
