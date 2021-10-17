using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class userandemployeerealtionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeID",
                table: "User",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employee_EmployeeID",
                table: "User",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Employee_EmployeeID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EmployeeID",
                table: "User");
        }
    }
}
