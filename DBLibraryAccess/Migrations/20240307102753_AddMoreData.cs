using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Book_BookId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BookId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "user_role_id",
                table: "User",
                type: "int",
                nullable: true,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "document_type_id",
                table: "User",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "publisher_code",
                table: "Book",
                type: "int",
                nullable: true,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_available",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "first_name", "last_name" },
                values: new object[] { "Taras", "Shevchenko" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "id", "alias_name", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 4, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les", "Poddereviansky" },
                    { 5, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikle", "Shur" }
                });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 1,
                column: "is_available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 2,
                column: "is_available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 3,
                column: "is_available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 4,
                column: "is_available",
                value: false);

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "city", "country", "is_available", "publication_year", "publisher_code", "title" },
                values: new object[,]
                {
                    { 5, "New York", "USA", false, 2017, 2, "Book5" },
                    { 6, "Washington", "USA", false, 2016, 1, "Book6" },
                    { 7, "Los Angeles", "USA", false, 2015, 1, "Book7" },
                    { 8, "San Francisco", "USA", false, 2014, 2, "Book8" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                column: "document_type_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 3, 3 },
                column: "ReturnDate",
                value: new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "author_id", "book_id" },
                values: new object[,]
                {
                    { 3, 6 },
                    { 4, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 7 },
                    { 5, 8 }
                });

            migrationBuilder.InsertData(
                table: "UserBook",
                columns: new[] { "book_id", "user_id", "Comment", "ReturnDate", "TookDate" },
                values: new object[,]
                {
                    { 6, 2, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "author_id", "book_id" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "is_available",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "user_role_id",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "document_type_id",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "publisher_code",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 2);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "first_name", "last_name" },
                values: new object[] { "Jack", "Doe" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "BookId", "document_type_id" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "BookId",
                value: null);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "BookId",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 3, 3 },
                column: "ReturnDate",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_User_BookId",
                table: "User",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Book_BookId",
                table: "User",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "id");
        }
    }
}
