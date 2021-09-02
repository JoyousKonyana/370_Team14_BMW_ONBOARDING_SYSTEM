using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class addedAttributestolessonContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonContentName",
                table: "LessonContent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonContentType",
                table: "LessonContent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonContentName",
                table: "LessonContent");

            migrationBuilder.DropColumn(
                name: "LessonContentType",
                table: "LessonContent");
        }
    }
}
