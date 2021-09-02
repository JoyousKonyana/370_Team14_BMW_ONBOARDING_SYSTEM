using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class ChangedRelationshipofcourseandNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_Notification",
            //    table: "Course");

            //migrationBuilder.DropIndex(
            //    name: "IX_Course_NotificationID",
            //    table: "Course");

            //migrationBuilder.DropColumn(
            //    name: "NotificationID",
            //    table: "Course");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Notification",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CourseID",
                table: "Notification",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Course_CourseID",
                table: "Notification",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Course_CourseID",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_CourseID",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Notification");

            migrationBuilder.AddColumn<int>(
                name: "NotificationID",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_NotificationID",
                table: "Course",
                column: "NotificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Notification",
                table: "Course",
                column: "NotificationID",
                principalTable: "Notification",
                principalColumn: "NotificationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
