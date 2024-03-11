using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoryCheckout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook");

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "UserBook",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "city", "country" },
                values: new object[] { "Canbera", "Australia" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "city", "country", "publication_year", "publisher_code", "title" },
                values: new object[,]
                {
                    { 9, "Mumbai", "India", 2013, 3, "Book9" },
                    { 10, "Deli", "India", 2012, 3, "Book10" }
                });

            migrationBuilder.InsertData(
                table: "UserBook",
                columns: new[] { "id", "book_id", "Comment", "ReturnDate", "TookDate", "user_id" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 6, null, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 6, null, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 8, null, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 5, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 7, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 3, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_user_id",
                table: "UserBook",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_user_id",
                table: "UserBook");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "id",
                table: "UserBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook",
                columns: new[] { "user_id", "book_id" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "city", "country" },
                values: new object[] { "San Francisco", "USA" });

            migrationBuilder.InsertData(
                table: "UserBook",
                columns: new[] { "book_id", "user_id", "Comment", "ReturnDate", "TookDate" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, null, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2, null, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
