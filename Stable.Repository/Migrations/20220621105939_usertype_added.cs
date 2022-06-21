using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stable.Repository.Migrations
{
    public partial class usertype_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "UserType",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 21, 13, 59, 39, 301, DateTimeKind.Local).AddTicks(1409), new DateTime(2022, 6, 21, 13, 59, 39, 303, DateTimeKind.Local).AddTicks(813) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 20, 22, 57, 16, 521, DateTimeKind.Local).AddTicks(215), new DateTime(2022, 6, 20, 22, 57, 16, 522, DateTimeKind.Local).AddTicks(2992) });
        }
    }
}
