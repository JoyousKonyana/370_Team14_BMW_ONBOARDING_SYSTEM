using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class removedFileUploadingAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonContentBytes",
                table: "LessonContent");

            migrationBuilder.DropColumn(
                name: "LessonContentName",
                table: "LessonContent");

            migrationBuilder.DropColumn(
                name: "LessonContentType",
                table: "LessonContent");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "LessonContent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "LessonContent");

            migrationBuilder.AddColumn<byte[]>(
                name: "LessonContentBytes",
                table: "LessonContent",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonContentName",
                table: "LessonContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonContentType",
                table: "LessonContent",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
