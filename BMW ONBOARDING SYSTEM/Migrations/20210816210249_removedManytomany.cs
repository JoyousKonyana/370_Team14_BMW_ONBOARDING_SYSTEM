using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class removedManytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Question_QuestionId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_QuestionId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Quiz");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuizId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Quiz",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_QuestionId",
                table: "Quiz",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Question_QuestionId",
                table: "Quiz",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
