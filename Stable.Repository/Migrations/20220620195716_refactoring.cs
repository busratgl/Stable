using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stable.Repository.Migrations
{
    public partial class refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Balances");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 20, 22, 57, 16, 521, DateTimeKind.Local).AddTicks(215), new DateTime(2022, 6, 20, 22, 57, 16, 522, DateTimeKind.Local).AddTicks(2992) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Balances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 20, 22, 50, 3, 115, DateTimeKind.Local).AddTicks(283), new DateTime(2022, 6, 20, 22, 50, 3, 116, DateTimeKind.Local).AddTicks(4646) });
        }
    }
}
