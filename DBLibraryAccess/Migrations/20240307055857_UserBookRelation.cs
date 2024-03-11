using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserBookRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserBook",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    TookDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBook", x => new { x.user_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_user_book_book",
                        column: x => x.book_id,
                        principalTable: "Book",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_book_user",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "city", "country", "publication_year", "publisher_code", "title" },
                values: new object[,]
                {
                    { 3, "Lviv", "Ukraine", 2019, 3, "Book3" },
                    { 4, "Odessa", "USA", 2018, 3, "Book4" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "document_number", "document_type_id", "email", "last_name", "login", "password", "user_role_id" },
                values: new object[] { "09123", 1, "reader1@lib.lib", "Reader1", "reader", "111", 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "document_number", "document_type_id", "email", "last_name", "login", "password" },
                values: new object[] { "123321", 2, "reader2@lib.lib", "Reader2", "reader2", "222" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "document_number", "document_type_id", "email", "first_name", "last_name", "login", "password", "user_role_id" },
                values: new object[] { 1, null, null, "lib@lib.lib", null, "Librarian1", "librarian", "1234", 1 });

            migrationBuilder.InsertData(
                table: "UserBook",
                columns: new[] { "book_id", "user_id", "Comment", "ReturnDate", "TookDate" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, null, null, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_book_id",
                table: "UserBook",
                column: "book_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBook");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "took_by_user_id",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 1,
                column: "took_by_user_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 2,
                column: "took_by_user_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "document_number", "document_type_id", "email", "last_name", "login", "password", "user_role_id" },
                values: new object[] { null, null, null, null, "librarian", "1234", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "document_number", "document_type_id", "email", "last_name", "login", "password" },
                values: new object[] { null, null, null, null, "reader", "111" });

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
    }
}
