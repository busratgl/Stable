using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stable.Repository.Migrations
{
    public partial class deleted_UserIpAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIpAddress");

            migrationBuilder.AddColumn<string>(
                name: "RemoteIpAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 19, 13, 37, 7, 424, DateTimeKind.Local).AddTicks(4580), new DateTime(2022, 7, 19, 13, 37, 7, 425, DateTimeKind.Local).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 19, 13, 37, 7, 426, DateTimeKind.Local).AddTicks(5564), new DateTime(2022, 7, 19, 13, 37, 7, 426, DateTimeKind.Local).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1225), new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1233) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1525), new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1530), new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1533), new DateTime(2022, 7, 19, 13, 37, 7, 428, DateTimeKind.Local).AddTicks(1534) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemoteIpAddress",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserIpAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIpAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIpAddress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 18, 0, 331, DateTimeKind.Local).AddTicks(786), new DateTime(2022, 7, 13, 15, 18, 0, 332, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 18, 0, 333, DateTimeKind.Local).AddTicks(3268), new DateTime(2022, 7, 13, 15, 18, 0, 333, DateTimeKind.Local).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8529), new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8535) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8836), new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8842), new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "CurrencyTypes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8844), new DateTime(2022, 7, 13, 15, 18, 0, 334, DateTimeKind.Local).AddTicks(8845) });

            migrationBuilder.CreateIndex(
                name: "IX_UserIpAddress_UserId",
                table: "UserIpAddress",
                column: "UserId");
        }
    }
}
