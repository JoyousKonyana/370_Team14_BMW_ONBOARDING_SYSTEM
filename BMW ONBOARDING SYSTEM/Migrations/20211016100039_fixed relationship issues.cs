using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class fixedrelationshipissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonContentTypeId",
                table: "LessonContent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContent_ArchiveStatusID",
                table: "LessonContent",
                column: "ArchiveStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_LessonContent_LessonContentTypeId",
                table: "LessonContent",
                column: "LessonContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentBrandID",
                table: "Equipment",
                column: "EquipmentBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeID",
                table: "Equipment",
                column: "EquipmentTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentBrand_EquipmentBrandID",
                table: "Equipment",
                column: "EquipmentBrandID",
                principalTable: "EquipmentBrand",
                principalColumn: "EquipmentBrandID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentType_EquipmentTypeID",
                table: "Equipment",
                column: "EquipmentTypeID",
                principalTable: "EquipmentType",
                principalColumn: "EquipmentTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonContent_ArchiveStatus_ArchiveStatusID",
                table: "LessonContent",
                column: "ArchiveStatusID",
                principalTable: "ArchiveStatus",
                principalColumn: "ArchiveStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonContent_LessonContentType_LessonContentTypeId",
                table: "LessonContent",
                column: "LessonContentTypeId",
                principalTable: "LessonContentType",
                principalColumn: "LessonContentTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentBrand_EquipmentBrandID",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentType_EquipmentTypeID",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonContent_ArchiveStatus_ArchiveStatusID",
                table: "LessonContent");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonContent_LessonContentType_LessonContentTypeId",
                table: "LessonContent");

            migrationBuilder.DropIndex(
                name: "IX_LessonContent_ArchiveStatusID",
                table: "LessonContent");

            migrationBuilder.DropIndex(
                name: "IX_LessonContent_LessonContentTypeId",
                table: "LessonContent");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_EquipmentBrandID",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_EquipmentTypeID",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "LessonContentTypeId",
                table: "LessonContent");
        }
    }
}
