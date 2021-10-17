using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class employeeandtitlerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employee_TitleID",
                table: "Employee",
                column: "TitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Title_TitleID",
                table: "Employee",
                column: "TitleID",
                principalTable: "Title",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Title_TitleID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TitleID",
                table: "Employee");
        }
    }
}
