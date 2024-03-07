using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_available",
                table: "Book",
                newName: "is_in_library");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 5,
                column: "is_in_library",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_in_library",
                table: "Book",
                newName: "is_available");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 5,
                column: "is_available",
                value: true);
        }
    }
}
