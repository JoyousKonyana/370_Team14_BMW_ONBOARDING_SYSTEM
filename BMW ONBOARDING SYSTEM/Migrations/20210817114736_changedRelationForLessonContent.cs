using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class changedRelationForLessonContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonContent_Lesson",
                table: "LessonContent");

            //migrationBuilder.DropIndex(
            //    name: "IX_LessonContent_LessonID",
            //    table: "LessonContent");

            migrationBuilder.DropColumn(
                name: "LessonID",
                table: "LessonContent");

            migrationBuilder.AddColumn<int>(
                name: "LessonOutcomeId",
                table: "LessonContent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContent_LessonOutcomeId",
                table: "LessonContent",
                column: "LessonOutcomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonContent_LessonOutcome_LessonOutcomeId",
                table: "LessonContent",
                column: "LessonOutcomeId",
                principalTable: "LessonOutcome",
                principalColumn: "LessonOutcomeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonContent_LessonOutcome_LessonOutcomeId",
                table: "LessonContent");

            migrationBuilder.DropIndex(
                name: "IX_LessonContent_LessonOutcomeId",
                table: "LessonContent");

            migrationBuilder.DropColumn(
                name: "LessonOutcomeId",
                table: "LessonContent");

            migrationBuilder.AddColumn<int>(
                name: "LessonID",
                table: "LessonContent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContent_LessonID",
                table: "LessonContent",
                column: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonContent_Lesson",
                table: "LessonContent",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
