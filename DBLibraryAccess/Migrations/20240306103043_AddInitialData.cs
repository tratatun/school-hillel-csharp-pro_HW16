using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserRole",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRole",
                newName: "id");

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "id", "alias_name", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe" },
                    { 2, null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe" },
                    { 3, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "Passport" },
                    { 2, "Driver License" },
                    { 3, "ID Card" }
                });

            migrationBuilder.InsertData(
                table: "PublisherCode",
                columns: new[] { "id", "code" },
                values: new object[,]
                {
                    { 1, "PC1" },
                    { 2, "PC2" },
                    { 3, "PC3" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "id", "role" },
                values: new object[,]
                {
                    { 1, "Librarian" },
                    { 2, "Reader" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "city", "country", "publication_year", "publisher_code", "title", "took_by_user_id" },
                values: new object[,]
                {
                    { 1, "Kyiv", "Ukraine", 2021, 1, "Book1", null },
                    { 2, "Kharkiv", "Ukraine", 2020, 2, "Book2", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "document_number", "document_type_id", "email", "first_name", "last_name", "login", "password", "user_role_id" },
                values: new object[,]
                {
                    { 2, null, null, null, null, null, "librarian", "1234", 1 },
                    { 3, null, null, null, null, null, "reader", "111", 2 }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "author_id", "book_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DocumentType",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DocumentType",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DocumentType",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PublisherCode",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PublisherCode",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PublisherCode",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "role",
                table: "UserRole",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserRole",
                newName: "Id");
        }
    }
}
