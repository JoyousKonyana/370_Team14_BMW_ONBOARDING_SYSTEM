using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class newUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AchievementType_Badge",
            //    table: "AchievementType");

            //migrationBuilder.RenameColumn(
            //    name: "BadgeID",
            //    table: "AchievementType",
            //    newName: "BadgeId");

            //migrationBuilder.RenameColumn(
            //    name: "AchievementTypeID",
            //    table: "AchievementType",
            //    newName: "AchievementTypeId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_AchievementType_BadgeID",
            //    table: "AchievementType",
            //    newName: "IX_AchievementType_BadgeId");

            //migrationBuilder.AlterColumn<string>(
            //    name: "AchievementTypeDescription",
            //    table: "AchievementType",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)",
            //    oldMaxLength: 50,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "AchievementTypeId",
            //    table: "AchievementType",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementType_Badge_BadgeId",
                table: "AchievementType",
                column: "BadgeId",
                principalTable: "Badge",
                principalColumn: "BadgeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementType_Badge_BadgeId",
                table: "AchievementType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "BadgeId",
                table: "AchievementType",
                newName: "BadgeID");

            migrationBuilder.RenameColumn(
                name: "AchievementTypeId",
                table: "AchievementType",
                newName: "AchievementTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementType_BadgeId",
                table: "AchievementType",
                newName: "IX_AchievementType_BadgeID");

            migrationBuilder.AlterColumn<string>(
                name: "AchievementTypeDescription",
                table: "AchievementType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AchievementTypeID",
                table: "AchievementType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementType_Badge",
                table: "AchievementType",
                column: "BadgeID",
                principalTable: "Badge",
                principalColumn: "BadgeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
