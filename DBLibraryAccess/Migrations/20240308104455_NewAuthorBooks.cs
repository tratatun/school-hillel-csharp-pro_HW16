using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewAuthorBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "author_id", "book_id" },
                values: new object[,]
                {
                    { 3, 10 },
                    { 4, 9 }
                });

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 5,
                column: "ReturnDate",
                value: new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 5,
                column: "ReturnDate",
                value: new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
