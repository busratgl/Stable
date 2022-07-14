using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stable.Repository.Migrations
{
    public partial class adding_userIpAddress_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "UserIpAddress",
              columns: table => new
              {
                  Id = table.Column<long>(type: "bigint", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  UserId = table.Column<long>(type: "bigint", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
