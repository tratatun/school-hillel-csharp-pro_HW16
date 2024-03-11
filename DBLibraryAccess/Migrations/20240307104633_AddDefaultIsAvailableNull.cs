using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultIsAvailableNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_available",
                table: "Book",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 1,
                column: "is_available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 3,
                column: "is_available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 4,
                column: "is_available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 5,
                column: "is_available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 6,
                column: "is_available",
                value: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 7,
                column: "is_available",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 6, 2 },
                columns: new[] { "ReturnDate", "TookDate" },
                values: new object[] { new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserBook",
                columns: new[] { "book_id", "user_id", "Comment", "ReturnDate", "TookDate" },
                values: new object[,]
                {
                    { 5, 2, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2, null, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.AlterColumn<bool>(
                name: "is_available",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 1,
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

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 5,
                column: "is_available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 6,
                column: "is_available",
                value: false);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: 7,
                column: "is_available",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumns: new[] { "book_id", "user_id" },
                keyValues: new object[] { 6, 2 },
                columns: new[] { "ReturnDate", "TookDate" },
                values: new object[] { new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
