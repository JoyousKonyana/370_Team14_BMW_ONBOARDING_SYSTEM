using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class addedLessonOutcomeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("LessonOutcomeName", "LessonOutcome", "varchar(50)",
                unicode: false, maxLength: 50, nullable: true);
            //migrationBuilder.CreateTable(
            //    name: "Achievement",
            //    columns: table => new
            //    {
            //        AchievementID = table.Column<int>(nullable: false),
            //        AchievementDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        AchievementTypeID = table.Column<int>(nullable: true),
            //        OnboarderID = table.Column<int>(nullable: true),
            //        CourseID = table.Column<int>(nullable: true),
            //        QuizID = table.Column<int>(nullable: true),
            //        MarkAchieved = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ArchiveStatus",
            //    columns: table => new
            //    {
            //        ArchiveStatusID = table.Column<int>(nullable: false),
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
            //        BadgeID = table.Column<int>(nullable: false),
            //        BadgeDecription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Badge", x => x.BadgeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Certificate",
            //    columns: table => new
            //    {
            //        CertificateID = table.Column<int>(nullable: false),
            //        LessonCompletionStatusID = table.Column<int>(nullable: true),
            //        CertificateDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CertificateDateGenerated = table.Column<DateTime>(type: "datetime", nullable: true),
            //        CertificateTypeID = table.Column<int>(nullable: true),
            //        CourseCompletionStatusID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Certificate", x => x.CertificateID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CertificateType",
            //    columns: table => new
            //    {
            //        CertificateTypeID = table.Column<int>(nullable: false),
            //        CertificateTypeTemplate = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CertificateType", x => x.CertificateTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Course",
            //    columns: table => new
            //    {
            //        CourseID = table.Column<int>(nullable: false),
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
            //        CourseCopletionStatusID = table.Column<int>(nullable: false),
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
            //        DepatmentID = table.Column<int>(nullable: false),
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
            //        EmployeeCalendarID = table.Column<int>(nullable: false),
            //        EmployeeCalendarLink = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EmployeeCalendar", x => x.EmployeeCalendarID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Gender",
            //    columns: table => new
            //    {
            //        GenderID = table.Column<int>(nullable: false),
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
            //        LessonCompletionStatusID = table.Column<int>(nullable: false),
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
            //        LessonContentTypeID = table.Column<int>(nullable: false),
            //        LessonContentDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LessonContentType", x => x.LessonContentTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionBank",
            //    columns: table => new
            //    {
            //        QuestionBankID = table.Column<int>(nullable: false),
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
            //        TitleID = table.Column<int>(nullable: false),
            //        TitleDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Title", x => x.TitleID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AchievementType",
            //    columns: table => new
            //    {
            //        AchievementTypeID = table.Column<int>(nullable: false),
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
            //    name: "Lesson",
            //    columns: table => new
            //    {
            //        LessonID = table.Column<int>(nullable: false),
            //        CourseID = table.Column<int>(nullable: true),
            //        LessonCompletionStatusID = table.Column<int>(nullable: true),
            //        LessonDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
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
            //    name: "QuestionCategory",
            //    columns: table => new
            //    {
            //        QuestionCategoryID = table.Column<int>(nullable: false),
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
            //        EmployeeID = table.Column<int>(nullable: false),
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
            //    name: "LessonContent",
            //    columns: table => new
            //    {
            //        LessonConentID = table.Column<int>(nullable: false),
            //        LessonContenetTypeID = table.Column<int>(nullable: true),
            //        LessonID = table.Column<int>(nullable: true),
            //        ArchiveStatusID = table.Column<int>(nullable: true),
            //        LessonContentDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
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
            //            name: "FK_LessonContent_Lesson",
            //            column: x => x.LessonID,
            //            principalTable: "Lesson",
            //            principalColumn: "LessonID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.AddColumn(
            //    name: "LessonOutcome",
            //    columns: table => new
            //    {
            //        LessonOutcomeID = table.Column<int>(nullable: false),
            //        LessonID = table.Column<int>(nullable: true),
            //        LessonOutcomeDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LessonOutcomeName = table.Column<string>(nullable: true)
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
            //    name: "Onboarder",
            //    columns: table => new
            //    {
            //        OnboarderID = table.Column<int>(nullable: false),
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
            //    name: "Quiz",
            //    columns: table => new
            //    {
            //        QuizID = table.Column<int>(nullable: false),
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
            //    name: "Question",
            //    columns: table => new
            //    {
            //        QuestionID = table.Column<int>(nullable: false),
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

            //migrationBuilder.CreateIndex(
            //    name: "IX_AchievementType_BadgeID",
            //    table: "AchievementType",
            //    column: "BadgeID");

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
            //    name: "IX_LessonContent_LessonID",
            //    table: "LessonContent",
            //    column: "LessonID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LessonOutcome_LessonID",
            //    table: "LessonOutcome",
            //    column: "LessonID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Onboarder_EmployeeID",
            //    table: "Onboarder",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OnboarderCourseEnrollment_OnboarderID",
            //    table: "OnboarderCourseEnrollment",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "AchievementType");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "CertificateType");

            migrationBuilder.DropTable(
                name: "CourseCompletionStatus");

            migrationBuilder.DropTable(
                name: "LessonContent");

            migrationBuilder.DropTable(
                name: "OnboarderCourseEnrollment");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "ArchiveStatus");

            migrationBuilder.DropTable(
                name: "LessonContentType");

            migrationBuilder.DropTable(
                name: "Onboarder");

            migrationBuilder.DropTable(
                name: "QuestionCategory");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "LessonOutcome");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeCalendar");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "LessonCompletionStatus");
        }
    }
}
