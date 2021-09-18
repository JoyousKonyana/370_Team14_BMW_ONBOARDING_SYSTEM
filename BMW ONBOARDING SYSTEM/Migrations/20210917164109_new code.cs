using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class newcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "OTP",
            //    columns: table => new
            //    {
            //        OTP_ID = table.Column<int>(name: "[OTP_ID", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        User_ID = table.Column<int>(nullable: false),
            //        OTP = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        Timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OTP", x => x.OTP_ID);
            //        table.ForeignKey(
            //            name: "FK_OTP_User",
            //            column: x => x.User_ID,
            //            principalTable: "User",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_OTP_User_ID",
            //    table: "OTP",
            //    column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTP");
        }
    }
}
