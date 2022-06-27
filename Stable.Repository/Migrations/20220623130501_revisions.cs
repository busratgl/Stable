using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stable.Repository.Migrations
{
    public partial class revisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 23, 16, 5, 1, 342, DateTimeKind.Local).AddTicks(4204), new DateTime(2022, 6, 23, 16, 5, 1, 343, DateTimeKind.Local).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 23, 16, 5, 1, 344, DateTimeKind.Local).AddTicks(6148), new DateTime(2022, 6, 23, 16, 5, 1, 344, DateTimeKind.Local).AddTicks(6155) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1366), new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1720), new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1723) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1726), new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1727) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1729), new DateTime(2022, 6, 23, 16, 5, 1, 346, DateTimeKind.Local).AddTicks(1730) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 22, 23, 43, 24, 432, DateTimeKind.Local).AddTicks(9551), new DateTime(2022, 6, 22, 23, 43, 24, 434, DateTimeKind.Local).AddTicks(3091) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 22, 23, 43, 24, 435, DateTimeKind.Local).AddTicks(1542), new DateTime(2022, 6, 22, 23, 43, 24, 435, DateTimeKind.Local).AddTicks(1549) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(7823), new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(8155), new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(8157) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(8161), new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(8164), new DateTime(2022, 6, 22, 23, 43, 24, 436, DateTimeKind.Local).AddTicks(8164) });
        }
    }
}
