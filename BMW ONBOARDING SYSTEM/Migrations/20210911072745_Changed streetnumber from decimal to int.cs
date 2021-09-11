using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class Changedstreetnumberfromdecimaltoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Achievement",
            //    columns: table => new
            //    {
            //        AchievementID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AchievementDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        AchievementTypeID = table.Column<int>(nullable: true),
            //        OnboarderID = table.Column<int>(nullable: true),
            //        CourseID = table.Column<int>(nullable: true),
            //        QuizID = table.Column<int>(nullable: true),
            //        MarkAchieved = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Achievement", x => x.AchievementID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ArchiveStatus",
            //    columns: table => new
            //    {
            //        ArchiveStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ArchieveStatusDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ArchiveStatus", x => x.ArchiveStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Badge",
            //    columns: table => new
            //    {
            //        BadgeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BadgeDecription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Badge", x => x.BadgeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "City",
            //    columns: table => new
            //    {
            //        CityID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Country = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_City", x => x.CityID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Country",
            //    columns: table => new
            //    {
            //        CountryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CountryName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Country", x => x.CountryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Course",
            //    columns: table => new
            //    {
            //        CourseID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CourseDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CourseDueDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        CourseName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Course", x => x.CourseID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CourseCompletionStatus",
            //    columns: table => new
            //    {
            //        CourseCopletionStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OnboarderID = table.Column<int>(nullable: true),
            //        CourseID = table.Column<int>(nullable: true),
            //        CourseCompletionStatusDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CourseCompletionStatusDate = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Department",
            //    columns: table => new
            //    {
            //        DepatmentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Department", x => x.DepatmentID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EmployeeCalendar",
            //    columns: table => new
            //    {
            //        EmployeeCalendarID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeCalendarLink = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EmployeeCalendar", x => x.EmployeeCalendarID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipmentBrand",
            //    columns: table => new
            //    {
            //        EquipmentBrandID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentBrandName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipmentBrand", x => x.EquipmentBrandID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipmentTradeInStatus",
            //    columns: table => new
            //    {
            //        EquipmentTradeInStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentTradeInStatusDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipmentTradeInStatus", x => x.EquipmentTradeInStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipmentType",
            //    columns: table => new
            //    {
            //        EquipmentTypeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentTypeDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipmentType", x => x.EquipmentTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FAQ",
            //    columns: table => new
            //    {
            //        FAQID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FAQDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        FAQAnswer = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FAQ", x => x.FAQID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Gender",
            //    columns: table => new
            //    {
            //        GenderID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GenderDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Gender", x => x.GenderID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LessonCompletionStatus",
            //    columns: table => new
            //    {
            //        LessonCompletionStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LessonCompletionStatusDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LessonCompletionDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LessonCompletionStatus", x => x.LessonCompletionStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LessonContentType",
            //    columns: table => new
            //    {
            //        LessonContentTypeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LessonContentDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LessonContentType", x => x.LessonContentTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostalCode",
            //    columns: table => new
            //    {
            //        PostalCodeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostalCode", x => x.PostalCodeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Province",
            //    columns: table => new
            //    {
            //        ProvinceID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProvinceName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Province", x => x.ProvinceID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QueryStatus",
            //    columns: table => new
            //    {
            //        EquipmentQueryStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentQueryDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QueryStatus", x => x.EquipmentQueryStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionBank",
            //    columns: table => new
            //    {
            //        QuestionBankID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionBankDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QuestionBank", x => x.QuestionBankID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Title",
            //    columns: table => new
            //    {
            //        TitleID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TitleDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Title", x => x.TitleID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRole",
            //    columns: table => new
            //    {
            //        UserRoleID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserRoleDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        UserRoleName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRole", x => x.UserRoleID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Warranty",
            //    columns: table => new
            //    {
            //        WarrantyID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        WarrantyStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        WarrantyENdDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        WarrantyStatus = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Warranty", x => x.WarrantyID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AchievementType",
            //    columns: table => new
            //    {
            //        AchievementTypeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AchievementTypeDescription = table.Column<string>(maxLength: 50, nullable: true),
            //        BadgeID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AchievementType", x => x.AchievementTypeID);
            //        table.ForeignKey(
            //            name: "FK_AchievementType_Badge",
            //            column: x => x.BadgeID,
            //            principalTable: "Badge",
            //            principalColumn: "BadgeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notification",
            //    columns: table => new
            //    {
            //        NotificationID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NotificationTypeID = table.Column<int>(nullable: true),
            //        NotificationMessageDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CourseID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notification", x => x.NotificationID);
            //        table.ForeignKey(
            //            name: "FK_Notification_Course",
            //            column: x => x.CourseID,
            //            principalTable: "Course",
            //            principalColumn: "CourseID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Lesson",
            //    columns: table => new
            //    {
            //        LessonID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CourseID = table.Column<int>(nullable: true),
            //        LessonCompletionStatusID = table.Column<int>(nullable: true),
            //        LessonDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LessonName = table.Column<byte[]>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Lesson", x => x.LessonID);
            //        table.ForeignKey(
            //            name: "FK_Lesson_Course",
            //            column: x => x.CourseID,
            //            principalTable: "Course",
            //            principalColumn: "CourseID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Lesson_LessonCompletionStatus",
            //            column: x => x.LessonCompletionStatusID,
            //            principalTable: "LessonCompletionStatus",
            //            principalColumn: "LessonCompletionStatusID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Suburb",
            //    columns: table => new
            //    {
            //        SuburbID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostalCodeID = table.Column<int>(nullable: true),
            //        SuburbName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Suburb", x => x.SuburbID);
            //        table.ForeignKey(
            //            name: "FK_Suburb_PostalCode",
            //            column: x => x.PostalCodeID,
            //            principalTable: "PostalCode",
            //            principalColumn: "PostalCodeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionCategory",
            //    columns: table => new
            //    {
            //        QuestionCategoryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionBankID = table.Column<int>(nullable: true),
            //        QuestionCategoryDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QuestionCategory", x => x.QuestionCategoryID);
            //        table.ForeignKey(
            //            name: "FK_QuestionCategory_QuestionBank",
            //            column: x => x.QuestionBankID,
            //            principalTable: "QuestionBank",
            //            principalColumn: "QuestionBankID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        EmployeeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentID = table.Column<int>(nullable: true),
            //        GenderID = table.Column<int>(nullable: true),
            //        AddressID = table.Column<int>(nullable: true),
            //        EmployeeCalendarID = table.Column<int>(nullable: true),
            //        FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        MiddleName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        IDNumber = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
            //        EmailAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        ContactNumber = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
            //        EmployeeJobTitle = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        TitleID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.EmployeeID);
            //        table.ForeignKey(
            //            name: "FK_Employee_Department",
            //            column: x => x.DepartmentID,
            //            principalTable: "Department",
            //            principalColumn: "DepatmentID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Employee_Calendar",
            //            column: x => x.EmployeeCalendarID,
            //            principalTable: "EmployeeCalendar",
            //            principalColumn: "EmployeeCalendarID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Employee_Gender",
            //            column: x => x.GenderID,
            //            principalTable: "Gender",
            //            principalColumn: "GenderID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Employee_Title",
            //            column: x => x.TitleID,
            //            principalTable: "Title",
            //            principalColumn: "TitleID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    columns: table => new
            //    {
            //        UserID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Username = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Password = table.Column<string>(unicode: false, nullable: true),
            //        EmployeeID = table.Column<int>(nullable: true),
            //        UserRoleID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.UserID);
            //        table.ForeignKey(
            //            name: "FK_User_UserRole",
            //            column: x => x.UserRoleID,
            //            principalTable: "UserRole",
            //            principalColumn: "UserRoleID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Equipment",
            //    columns: table => new
            //    {
            //        EquipmentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentTypeID = table.Column<int>(nullable: true),
            //        EquipmentTradeInStatus = table.Column<int>(nullable: true),
            //        WarrantyID = table.Column<int>(nullable: true),
            //        EquipmentBrandID = table.Column<int>(nullable: true),
            //        EquipmentTradeUnDeadline = table.Column<DateTime>(type: "datetime", nullable: true),
            //        EquipmentSerialNumber = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Equipment", x => x.EquipmentID);
            //        table.ForeignKey(
            //            name: "FK_Equipment_EquipmentBrand",
            //            column: x => x.EquipmentBrandID,
            //            principalTable: "EquipmentBrand",
            //            principalColumn: "EquipmentBrandID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Equipment_EquipmentTradeInStatus",
            //            column: x => x.EquipmentTradeInStatus,
            //            principalTable: "EquipmentTradeInStatus",
            //            principalColumn: "EquipmentTradeInStatusID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Equipment_EquipmentType",
            //            column: x => x.EquipmentTypeID,
            //            principalTable: "EquipmentType",
            //            principalColumn: "EquipmentTypeID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Equipment_Warranty",
            //            column: x => x.WarrantyID,
            //            principalTable: "Warranty",
            //            principalColumn: "WarrantyID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LessonOutcome",
            //    columns: table => new
            //    {
            //        LessonOutcomeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LessonID = table.Column<int>(nullable: true),
            //        LessonOutcomeDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LessonOutcomeName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LessonOutcome", x => x.LessonOutcomeID);
            //        table.ForeignKey(
            //            name: "FK_LessonOutcome_Lesson",
            //            column: x => x.LessonID,
            //            principalTable: "Lesson",
            //            principalColumn: "LessonID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Address",
            //    columns: table => new
            //    {
            //        AddressID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SuburbID = table.Column<int>(nullable: true),
            //        ProvinceID = table.Column<int>(nullable: true),
            //        CityID = table.Column<int>(nullable: true),
            //        CountryID = table.Column<int>(nullable: true),
            //        StreetNumber = table.Column<int>(nullable: false),
            //        StreetName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Address", x => x.AddressID);
            //        table.ForeignKey(
            //            name: "FK_Address_City",
            //            column: x => x.CityID,
            //            principalTable: "City",
            //            principalColumn: "CityID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Address_Country",
            //            column: x => x.CountryID,
            //            principalTable: "Country",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Address_Province",
            //            column: x => x.ProvinceID,
            //            principalTable: "Province",
            //            principalColumn: "ProvinceID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Address_Suburb",
            //            column: x => x.SuburbID,
            //            principalTable: "Suburb",
            //            principalColumn: "SuburbID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Onboarder",
            //    columns: table => new
            //    {
            //        OnboarderID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Onboarder", x => x.OnboarderID);
            //        table.ForeignKey(
            //            name: "FK_Onboarder_Employee",
            //            column: x => x.EmployeeID,
            //            principalTable: "Employee",
            //            principalColumn: "EmployeeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ActiveLog",
            //    columns: table => new
            //    {
            //        ActiveLogID = table.Column<int>(nullable: false),
            //        UserID = table.Column<int>(nullable: true),
            //        ActiveLogDeviceIPAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        ActiveLogLoginTimestamp = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ActiveLogLoginLastActiveTimestamp = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ActiveLog", x => x.ActiveLogID);
            //        table.ForeignKey(
            //            name: "FK_ActiveLog_User",
            //            column: x => x.UserID,
            //            principalTable: "User",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AuditLog",
            //    columns: table => new
            //    {
            //        AuditLogID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(nullable: true),
            //        AuditLogDatestamp = table.Column<DateTime>(type: "date", nullable: true),
            //        AuditLogTimestamp = table.Column<TimeSpan>(nullable: true),
            //        AuditLogDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AuditLog", x => x.AuditLogID);
            //        table.ForeignKey(
            //            name: "FK_AuditLog_User",
            //            column: x => x.UserID,
            //            principalTable: "User",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LessonContent",
            //    columns: table => new
            //    {
            //        LessonConentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LessonContenetTypeID = table.Column<int>(nullable: true),
            //        LessonOutcomeID = table.Column<int>(nullable: true),
            //        ArchiveStatusID = table.Column<int>(nullable: true),
            //        LessonContentDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LessonContent = table.Column<string>(unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LessonContent", x => x.LessonConentID);
            //        table.ForeignKey(
            //            name: "FK_LessonContent_ArchiveStatus1",
            //            column: x => x.ArchiveStatusID,
            //            principalTable: "ArchiveStatus",
            //            principalColumn: "ArchiveStatusID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LessonContent_LessonContentType",
            //            column: x => x.LessonContenetTypeID,
            //            principalTable: "LessonContentType",
            //            principalColumn: "LessonContentTypeID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LessonContent_LessonOutcome",
            //            column: x => x.LessonOutcomeID,
            //            principalTable: "LessonOutcome",
            //            principalColumn: "LessonOutcomeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Quiz",
            //    columns: table => new
            //    {
            //        QuizID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LessonOutcomeID = table.Column<int>(nullable: true),
            //        QuizDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        QuizMarkRequirement = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        QuizDueDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        QuizCompletionDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        NumberOfQuestions = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Quiz", x => x.QuizID);
            //        table.ForeignKey(
            //            name: "FK_Quiz_LessonOutcome",
            //            column: x => x.LessonOutcomeID,
            //            principalTable: "LessonOutcome",
            //            principalColumn: "LessonOutcomeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OnboarderCourseEnrollment",
            //    columns: table => new
            //    {
            //        CourseID = table.Column<int>(nullable: false),
            //        OnboarderID = table.Column<int>(nullable: false),
            //        OnboarderEnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        BadgeTotal = table.Column<int>(nullable: true),
            //        OnboarderGraduationDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OnboarderCourseEnrollment", x => x.CourseID);
            //        table.ForeignKey(
            //            name: "FK_OnboarderCourseEnrollment_Course",
            //            column: x => x.CourseID,
            //            principalTable: "Course",
            //            principalColumn: "CourseID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OnboarderCourseEnrollment_Onboarder",
            //            column: x => x.OnboarderID,
            //            principalTable: "Onboarder",
            //            principalColumn: "OnboarderID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OnboarderEquipment",
            //    columns: table => new
            //    {
            //        EquipmentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OnboarderID = table.Column<int>(nullable: false),
            //        EquipmentCheckOutDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        EquipmentCheckInDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        EquipmentCheckInCondition = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OnboarderEquipment", x => x.EquipmentID);
            //        table.ForeignKey(
            //            name: "FK_OnboarderEquipment_Equipment",
            //            column: x => x.EquipmentID,
            //            principalTable: "Equipment",
            //            principalColumn: "EquipmentID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OnboarderEquipment_Onboarder",
            //            column: x => x.OnboarderID,
            //            principalTable: "Onboarder",
            //            principalColumn: "OnboarderID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Question",
            //    columns: table => new
            //    {
            //        QuestionID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuizID = table.Column<int>(nullable: true),
            //        QuestionCategoryID = table.Column<int>(nullable: true),
            //        QuestionDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        QuestionAnswer = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        QuestionMarkAllocation = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Question", x => x.QuestionID);
            //        table.ForeignKey(
            //            name: "FK_Question_QuestionCategory",
            //            column: x => x.QuestionCategoryID,
            //            principalTable: "QuestionCategory",
            //            principalColumn: "QuestionCategoryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Question_Quiz",
            //            column: x => x.QuizID,
            //            principalTable: "Quiz",
            //            principalColumn: "QuizID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipmentQuery",
            //    columns: table => new
            //    {
            //        EquipmentQueryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentID = table.Column<int>(nullable: true),
            //        OnboarderID = table.Column<int>(nullable: true),
            //        EquipmentQueryDescription = table.Column<string>(unicode: false, nullable: true),
            //        EquipmentQueryDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipmentQuery", x => x.EquipmentQueryID);
            //        table.ForeignKey(
            //            name: "FK_EquipmentQuery_OnboarderEquipment",
            //            column: x => x.EquipmentID,
            //            principalTable: "OnboarderEquipment",
            //            principalColumn: "EquipmentID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipmentQueryStatus.",
            //    columns: table => new
            //    {
            //        EquipmentQueryStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EquipmentQueryID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipmentQueryStatus.", x => x.EquipmentQueryStatusID);
            //        table.ForeignKey(
            //            name: "FK_EquipmentQueryStatus._EquipmentQuery",
            //            column: x => x.EquipmentQueryID,
            //            principalTable: "EquipmentQuery",
            //            principalColumn: "EquipmentQueryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_EquipmentQueryStatus._QueryStatus",
            //            column: x => x.EquipmentQueryStatusID,
            //            principalTable: "QueryStatus",
            //            principalColumn: "EquipmentQueryStatusID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AchievementType_BadgeID",
            //    table: "AchievementType",
            //    column: "BadgeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ActiveLog_UserID",
            //    table: "ActiveLog",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Address_CityID",
            //    table: "Address",
            //    column: "CityID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Address_CountryID",
            //    table: "Address",
            //    column: "CountryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Address_ProvinceID",
            //    table: "Address",
            //    column: "ProvinceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Address_SuburbID",
            //    table: "Address",
            //    column: "SuburbID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AuditLog_UserID",
            //    table: "AuditLog",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_DepartmentID",
            //    table: "Employee",
            //    column: "DepartmentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_EmployeeCalendarID",
            //    table: "Employee",
            //    column: "EmployeeCalendarID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_GenderID",
            //    table: "Employee",
            //    column: "GenderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_TitleID",
            //    table: "Employee",
            //    column: "TitleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Equipment_EquipmentBrandID",
            //    table: "Equipment",
            //    column: "EquipmentBrandID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Equipment_EquipmentTradeInStatus",
            //    table: "Equipment",
            //    column: "EquipmentTradeInStatus");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Equipment_EquipmentTypeID",
            //    table: "Equipment",
            //    column: "EquipmentTypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Equipment_WarrantyID",
            //    table: "Equipment",
            //    column: "WarrantyID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EquipmentQuery_EquipmentID",
            //    table: "EquipmentQuery",
            //    column: "EquipmentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EquipmentQueryStatus._EquipmentQueryID",
            //    table: "EquipmentQueryStatus.",
            //    column: "EquipmentQueryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Lesson_CourseID",
            //    table: "Lesson",
            //    column: "CourseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Lesson_LessonCompletionStatusID",
            //    table: "Lesson",
            //    column: "LessonCompletionStatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LessonContent_ArchiveStatusID",
            //    table: "LessonContent",
            //    column: "ArchiveStatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LessonContent_LessonContenetTypeID",
            //    table: "LessonContent",
            //    column: "LessonContenetTypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LessonContent_LessonOutcomeID",
            //    table: "LessonContent",
            //    column: "LessonOutcomeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LessonOutcome_LessonID",
            //    table: "LessonOutcome",
            //    column: "LessonID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Notification_CourseID",
            //    table: "Notification",
            //    column: "CourseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Onboarder_EmployeeID",
            //    table: "Onboarder",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OnboarderCourseEnrollment_OnboarderID",
            //    table: "OnboarderCourseEnrollment",
            //    column: "OnboarderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OnboarderEquipment_OnboarderID",
            //    table: "OnboarderEquipment",
            //    column: "OnboarderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Question_QuestionCategoryID",
            //    table: "Question",
            //    column: "QuestionCategoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Question_QuizID",
            //    table: "Question",
            //    column: "QuizID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_QuestionCategory_QuestionBankID",
            //    table: "QuestionCategory",
            //    column: "QuestionBankID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Quiz_LessonOutcomeID",
            //    table: "Quiz",
            //    column: "LessonOutcomeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Suburb_PostalCodeID",
            //    table: "Suburb",
            //    column: "PostalCodeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_User_UserRoleID",
            //    table: "User",
            //    column: "UserRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "AchievementType");

            migrationBuilder.DropTable(
                name: "ActiveLog");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "CourseCompletionStatus");

            migrationBuilder.DropTable(
                name: "EquipmentQueryStatus.");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "LessonContent");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OnboarderCourseEnrollment");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EquipmentQuery");

            migrationBuilder.DropTable(
                name: "QueryStatus");

            migrationBuilder.DropTable(
                name: "ArchiveStatus");

            migrationBuilder.DropTable(
                name: "LessonContentType");

            migrationBuilder.DropTable(
                name: "QuestionCategory");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "PostalCode");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "OnboarderEquipment");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "LessonOutcome");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Onboarder");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "EquipmentBrand");

            migrationBuilder.DropTable(
                name: "EquipmentTradeInStatus");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "LessonCompletionStatus");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeCalendar");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
