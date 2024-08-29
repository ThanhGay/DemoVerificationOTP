using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoVerificationOTP.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateAt",
                table: "Student",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Student",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateAt",
                table: "Student",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Student");
        }
    }
}
