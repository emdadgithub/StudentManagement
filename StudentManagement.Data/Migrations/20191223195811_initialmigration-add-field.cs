using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Data.Migrations
{
    public partial class initialmigrationaddfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RollNo",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RollNo",
                table: "Students");
        }
    }
}
