using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class newdatabasewithfixedcompositekeyissues : Migration
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
            //        StreetNumber = table.Column<string>(nullable: true),
            //        StreetName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Address", x => x.AddressID);
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
            //    name: "Lesson",
            //    columns: table => new
            //    {
            //        LessonID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CourseID = table.Column<int>(nullable: true),
            //        LessonCompletionStatusID = table.Column<int>(nullable: true),
            //        LessonDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LessonName = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Lesson", x => x.LessonID);
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
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Option",
            //    columns: table => new
            //    {
            //        OptionId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionId = table.Column<int>(nullable: false),
            //        OptionNumber = table.Column<int>(nullable: false),
            //        OptionDescription = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Option", x => x.OptionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OTP",
            //    columns: table => new
            //    {
            //        OTP_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        User_ID = table.Column<int>(nullable: false),
            //        OtpValue = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        Timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OTP", x => x.OTP_ID);
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
            //    name: "Onboarder",
            //    columns: table => new
            //    {
            //        OnboarderID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Onboarder", x => x.OnboarderID);
            //        table.ForeignKey(
            //            name: "FK__Onboarder__Emplo__5AEE82B9",
            //            column: x => x.EmployeeID,
            //            principalTable: "Employee",
            //            principalColumn: "EmployeeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OnboarderCourseEnrollment",
            //    columns: table => new
            //    {
            //        OnboarderID = table.Column<int>(nullable: false),
            //        CourseID = table.Column<int>(nullable: false),
            //        OnboarderEnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        BadgeTotal = table.Column<int>(nullable: false),
            //        OnboarderGraduationDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Onboarde__2C42895D6775A25D", x => new { x.OnboarderID, x.CourseID });
            //        table.ForeignKey(
            //            name: "FK__Onboarder__Cours__5EBF139D",
            //            column: x => x.CourseID,
            //            principalTable: "Course",
            //            principalColumn: "CourseID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Onboarder__Onboa__5DCAEF64",
            //            column: x => x.OnboarderID,
            //            principalTable: "Onboarder",
            //            principalColumn: "OnboarderID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OnboarderEquipment",
            //    columns: table => new
            //    {
            //        EquipmentID = table.Column<int>(nullable: false),
            //        OnboarderID = table.Column<int>(nullable: false),
            //        EquipmentCheckOutDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        EquipmentCheckInDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        EquipmentCheckInCondition = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Onboarde__704A407DF2C8652A", x => new { x.EquipmentID, x.OnboarderID });
            //        table.ForeignKey(
            //            name: "FK__Onboarder__Equip__628FA481",
            //            column: x => x.EquipmentID,
            //            principalTable: "Equipment",
            //            principalColumn: "EquipmentID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Onboarder__Onboa__619B8048",
            //            column: x => x.OnboarderID,
            //            principalTable: "Onboarder",
            //            principalColumn: "OnboarderID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Onboarder_EmployeeID",
            //    table: "Onboarder",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OnboarderCourseEnrollment_CourseID",
            //    table: "OnboarderCourseEnrollment",
            //    column: "CourseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OnboarderEquipment_OnboarderID",
            //    table: "OnboarderEquipment",
            //    column: "OnboarderID");
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
                name: "ArchiveStatus");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "CourseCompletionStatus");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeCalendar");

            migrationBuilder.DropTable(
                name: "EquipmentBrand");

            migrationBuilder.DropTable(
                name: "EquipmentQuery");

            migrationBuilder.DropTable(
                name: "EquipmentQueryStatus.");

            migrationBuilder.DropTable(
                name: "EquipmentTradeInStatus");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "LessonCompletionStatus");

            migrationBuilder.DropTable(
                name: "LessonContent");

            migrationBuilder.DropTable(
                name: "LessonContentType");

            migrationBuilder.DropTable(
                name: "LessonOutcome");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OnboarderCourseEnrollment");

            migrationBuilder.DropTable(
                name: "OnboarderEquipment");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "OTP");

            migrationBuilder.DropTable(
                name: "PostalCode");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "QueryStatus");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "QuestionCategory");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Onboarder");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
