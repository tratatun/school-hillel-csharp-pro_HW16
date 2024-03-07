using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBLibraryAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRelateons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "book_id", "ReturnDate", "TookDate" },
                values: new object[] { 8, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "book_id", "ReturnDate", "TookDate", "user_id" },
                values: new object[] { 5, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "book_id", "ReturnDate", "TookDate" },
                values: new object[] { 7, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserBook",
                columns: new[] { "id", "book_id", "Comment", "ReturnDate", "TookDate", "user_id" },
                values: new object[,]
                {
                    { 9, 7, null, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 3, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "book_id", "ReturnDate", "TookDate" },
                values: new object[] { 5, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "book_id", "ReturnDate", "TookDate", "user_id" },
                values: new object[] { 7, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "UserBook",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "book_id", "ReturnDate", "TookDate" },
                values: new object[] { 3, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
