using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class TookByUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "took_by_user_id",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_took_by_user_id",
                table: "Book",
                column: "took_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_took_by_user_id",
                table: "Book",
                column: "took_by_user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_took_by_user_id",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_took_by_user_id",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "took_by_user_id",
                table: "Book");
        }
    }
}
