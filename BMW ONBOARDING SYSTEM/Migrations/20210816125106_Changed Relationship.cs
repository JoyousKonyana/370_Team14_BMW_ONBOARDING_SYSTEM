using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class ChangedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz",
                table: "Question");

            //migrationBuilder.DropIndex(
            //    name: "IX_Question_QuizID",
            //    table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizID",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Quiz",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Question_QuestionId",
                table: "Quiz");

            //migrationBuilder.DropIndex(
            //    name: "IX_Quiz_QuestionId",
            //    table: "Quiz");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Quiz");

            migrationBuilder.AddColumn<int>(
                name: "QuizID",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                column: "QuizID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz",
                table: "Question",
                column: "QuizID",
                principalTable: "Quiz",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
