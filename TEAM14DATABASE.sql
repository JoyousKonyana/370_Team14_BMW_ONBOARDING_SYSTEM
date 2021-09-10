USE [master]
GO
/****** Object:  Database [INF 370]    Script Date: 9/2/2021 7:33:24 AM ******/
CREATE DATABASE [INF 370]
 
GO
USE [INF 370]
GO
/****** Object:  Table [dbo].[Achievement]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievement](
	[AchievementID] [int] IDENTITY(1,1) NOT NULL,
	[AchievementDate] [datetime] NULL,
	[AchievementTypeID] [int] NULL,
	[OnboarderID] [int] NULL,
	[CourseID] [int] NULL,
	[QuizID] [int] NULL,
	[MarkAchieved] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Achievement] PRIMARY KEY CLUSTERED 
(
	[AchievementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AchievementType]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AchievementType](
	[AchievementTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AchievementTypeDescription] [nvarchar](50) NULL,
	[BadgeID] [int] NULL,
 CONSTRAINT [PK_AchievementType] PRIMARY KEY CLUSTERED 
(
	[AchievementTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActiveLog]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveLog](
	[ActiveLogID] [int] NOT NULL,
	[UserID] [int] NULL,
	[ActiveLogDeviceIPAddress] [varchar](50) NULL,
	[ActiveLogLoginTimestamp] [datetime] NULL,
	[ActiveLogLoginLastActiveTimestamp] [datetime] NULL,
 CONSTRAINT [PK_ActiveLog] PRIMARY KEY CLUSTERED 
(
	[ActiveLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[SuburbID] [int] NULL,
	[ProvinceID] [int] NULL,
	[CityID] [int] NULL,
	[CountryID] [int] NULL,
	[StreetNumber] [numeric](18, 0) NULL,
	[StreetName] [varchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArchiveStatus]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchiveStatus](
	[ArchiveStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ArchieveStatusDescription] [varchar](50) NULL,
 CONSTRAINT [PK_ArchiveStatus] PRIMARY KEY CLUSTERED 
(
	[ArchiveStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[AuditLogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AuditLogDatestamp] [date] NULL,
	[AuditLogTimestamp] [time](7) NULL,
	[AuditLogDescription] [varchar](50) NULL,
 CONSTRAINT [PK_AuditLog] PRIMARY KEY CLUSTERED 
(
	[AuditLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Badge]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badge](
	[BadgeID] [int] IDENTITY(1,1) NOT NULL,
	[BadgeDecription] [varchar](50) NULL,
 CONSTRAINT [PK_Badge] PRIMARY KEY CLUSTERED 
(
	[BadgeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseDescription] [varchar](50) NULL,
	[CourseDueDate] [datetime] NULL,
	[CourseName] [varchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseCompletionStatus]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCompletionStatus](
	[CourseCopletionStatusID] [int] IDENTITY(1,1) NOT NULL,
	[OnboarderID] [int] NULL,
	[CourseID] [int] NULL,
	[CourseCompletionStatusDescription] [varchar](50) NULL,
	[CourseCompletionStatusDate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepatmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentDescription] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepatmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NULL,
	[GenderID] [int] NULL,
	[AddressID] [int] NULL,
	[EmployeeCalendarID] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[IDNumber] [numeric](18, 0) NULL,
	[EmailAddress] [varchar](50) NULL,
	[ContactNumber] [numeric](18, 0) NULL,
	[EmployeeJobTitle] [varchar](50) NULL,
	[TitleID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeCalendar]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeCalendar](
	[EmployeeCalendarID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCalendarLink] [varchar](200) NULL,
 CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED 
(
	[EmployeeCalendarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentTypeID] [int] NULL,
	[EquipmentTradeInStatus] [int] NULL,
	[WarrantyID] [int] NULL,
	[EquipmentBrandID] [int] NULL,
	[EquipmentTradeUnDeadline] [datetime] NULL,
	[EquipmentSerialNumber] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentBrand]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBrand](
	[EquipmentBrandID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentBrandName] [varchar](50) NULL,
 CONSTRAINT [PK_EquipmentBrand] PRIMARY KEY CLUSTERED 
(
	[EquipmentBrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentQuery]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentQuery](
	[EquipmentQueryID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NULL,
	[OnboarderID] [int] NULL,
	[EquipmentQueryDescription] [varchar](max) NULL,
	[EquipmentQueryDate] [datetime] NULL,
 CONSTRAINT [PK_EquipmentQuery] PRIMARY KEY CLUSTERED 
(
	[EquipmentQueryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentQueryStatus.]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentQueryStatus.](
	[EquipmentQueryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentQueryID] [int] NULL,
 CONSTRAINT [PK_EquipmentQueryStatus.] PRIMARY KEY CLUSTERED 
(
	[EquipmentQueryStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentTradeInStatus]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTradeInStatus](
	[EquipmentTradeInStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentTradeInStatusDescription] [varchar](50) NULL,
 CONSTRAINT [PK_EquipmentTradeInStatus] PRIMARY KEY CLUSTERED 
(
	[EquipmentTradeInStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentType](
	[EquipmentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentTypeDescription] [varchar](50) NULL,
 CONSTRAINT [PK_EquipmentType] PRIMARY KEY CLUSTERED 
(
	[EquipmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[FAQID] [int] IDENTITY(1,1) NOT NULL,
	[FAQDescription] [varchar](50) NULL,
	[FAQAnswer] [varchar](50) NULL,
 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
(
	[FAQID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderDescription] [varchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NULL,
	[LessonCompletionStatusID] [int] NULL,
	[LessonDescription] [varchar](50) NULL,
	[LessonName] [varbinary](50) NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonCompletionStatus]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonCompletionStatus](
	[LessonCompletionStatusID] [int] IDENTITY(1,1) NOT NULL,
	[LessonCompletionStatusDescription] [varchar](50) NULL,
	[LessonCompletionDate] [datetime] NULL,
 CONSTRAINT [PK_LessonCompletionStatus] PRIMARY KEY CLUSTERED 
(
	[LessonCompletionStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonContent]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonContent](
	[LessonConentID] [int] IDENTITY(1,1) NOT NULL,
	[LessonContenetTypeID] [int] NULL,
	[LessonOutcomeID] [int] NULL,
	[ArchiveStatusID] [int] NULL,
	[LessonContentDescription] [varchar](50) NULL,
	[LessonContent] [varchar](max) NULL,
 CONSTRAINT [PK_LessonContent] PRIMARY KEY CLUSTERED 
(
	[LessonConentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonContentType]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonContentType](
	[LessonContentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LessonContentDescription] [varchar](50) NULL,
 CONSTRAINT [PK_LessonContentType] PRIMARY KEY CLUSTERED 
(
	[LessonContentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonOutcome]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonOutcome](
	[LessonOutcomeID] [int] IDENTITY(1,1) NOT NULL,
	[LessonID] [int] NULL,
	[LessonOutcomeDescription] [varchar](50) NULL,
	[LessonOutcomeName] [varchar](50) NULL,
 CONSTRAINT [PK_LessonOutcome] PRIMARY KEY CLUSTERED 
(
	[LessonOutcomeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationTypeID] [int] NULL,
	[NotificationMessageDescription] [varchar](50) NULL,
	[CourseID] [int] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Onboarder]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Onboarder](
	[OnboarderID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_Onboarder] PRIMARY KEY CLUSTERED 
(
	[OnboarderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OnboarderCourseEnrollment]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnboarderCourseEnrollment](
	[OnboarderID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[OnboarderEnrollmentDate] [datetime] NULL,
	[BadgeTotal] [int] NULL,
	[OnboarderGraduationDate] [datetime] NULL,
 CONSTRAINT [PK_OnboarderCourseEnrollment] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OnboarderEquipment]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnboarderEquipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[OnboarderID] [int] NOT NULL,
	[EquipmentCheckOutDate] [datetime] NULL,
	[EquipmentCheckInDate] [datetime] NULL,
	[EquipmentCheckInCondition] [varchar](50) NULL,
 CONSTRAINT [PK_OnboarderEquipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostalCode]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostalCode](
	[PostalCodeID] [int] IDENTITY(1,1) NOT NULL,
	[PostalCode] [varchar](50) NULL,
 CONSTRAINT [PK_PostalCode] PRIMARY KEY CLUSTERED 
(
	[PostalCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[ProvinceID] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceName] [varchar](50) NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QueryStatus]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueryStatus](
	[EquipmentQueryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentQueryDescription] [varchar](50) NULL,
 CONSTRAINT [PK_QueryStatus] PRIMARY KEY CLUSTERED 
(
	[EquipmentQueryStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[QuizID] [int] NULL,
	[QuestionCategoryID] [int] NULL,
	[QuestionDescription] [varchar](50) NULL,
	[QuestionAnswer] [varchar](50) NULL,
	[QuestionMarkAllocation] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionBank](
	[QuestionBankID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionBankDescription] [varchar](50) NULL,
 CONSTRAINT [PK_QuestionBank] PRIMARY KEY CLUSTERED 
(
	[QuestionBankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionCategory]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionCategory](
	[QuestionCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionBankID] [int] NULL,
	[QuestionCategoryDescription] [varchar](50) NULL,
 CONSTRAINT [PK_QuestionCategory] PRIMARY KEY CLUSTERED 
(
	[QuestionCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[QuizID] [int] IDENTITY(1,1) NOT NULL,
	[LessonOutcomeID] [int] NULL,
	[QuizDescription] [varchar](50) NULL,
	[QuizMarkRequirement] [varchar](50) NULL,
	[QuizDueDate] [datetime] NULL,
	[QuizCompletionDate] [datetime] NULL,
	[NumberOfQuestions] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suburb]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suburb](
	[SuburbID] [int] IDENTITY(1,1) NOT NULL,
	[PostalCodeID] [int] NULL,
	[SuburbName] [varchar](50) NULL,
 CONSTRAINT [PK_Suburb] PRIMARY KEY CLUSTERED 
(
	[SuburbID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[TitleID] [int] IDENTITY(1,1) NOT NULL,
	[TitleDescription] [varchar](50) NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[TitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](max) NULL,
	[EmployeeID] [int] NULL,
	[UserRoleID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleDescription] [varchar](50) NULL,
	[UserRoleName] [varchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warranty]    Script Date: 9/2/2021 7:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warranty](
	[WarrantyID] [int] IDENTITY(1,1) NOT NULL,
	[WarrantyStartDate] [datetime] NULL,
	[WarrantyENdDate] [datetime] NULL,
	[WarrantyStatus] [varchar](50) NULL,
 CONSTRAINT [PK_Warranty] PRIMARY KEY CLUSTERED 
(
	[WarrantyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Achievement] ON 
GO
INSERT [dbo].[Achievement] ([AchievementID], [AchievementDate], [AchievementTypeID], [OnboarderID], [CourseID], [QuizID], [MarkAchieved]) VALUES (1, NULL, 3, 1, 1, 1, CAST(95 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Achievement] OFF
GO
SET IDENTITY_INSERT [dbo].[AchievementType] ON 
GO
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (1, N'Bronze', NULL)
GO
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (2, N'zSilver', NULL)
GO
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (3, N'Gold', NULL)
GO
SET IDENTITY_INSERT [dbo].[AchievementType] OFF
GO
SET IDENTITY_INSERT [dbo].[ArchiveStatus] ON 
GO
INSERT [dbo].[ArchiveStatus] ([ArchiveStatusID], [ArchieveStatusDescription]) VALUES (1, N'Archived')
GO
INSERT [dbo].[ArchiveStatus] ([ArchiveStatusID], [ArchieveStatusDescription]) VALUES (2, N'Unarchived')
GO
SET IDENTITY_INSERT [dbo].[ArchiveStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Badge] ON 
GO
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (1, N'Bronze')
GO
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (2, N'Silver')
GO
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (3, N'Gold')
GO
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (4, N'Platinum')
GO
SET IDENTITY_INSERT [dbo].[Badge] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (1, N'Onboarding Course', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseCompletionStatus] ON 
GO
INSERT [dbo].[CourseCompletionStatus] ([CourseCopletionStatusID], [OnboarderID], [CourseID], [CourseCompletionStatusDescription], [CourseCompletionStatusDate]) VALUES (1, 1, 1, N'Complete', NULL)
GO
INSERT [dbo].[CourseCompletionStatus] ([CourseCopletionStatusID], [OnboarderID], [CourseID], [CourseCompletionStatusDescription], [CourseCompletionStatusDate]) VALUES (1, 2, 1, N'Incomplete', NULL)
GO
SET IDENTITY_INSERT [dbo].[CourseCompletionStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([DepatmentID], [DepartmentDescription]) VALUES (1, N'Analytics')
GO
INSERT [dbo].[Department] ([DepatmentID], [DepartmentDescription]) VALUES (2, N'Development')
GO
INSERT [dbo].[Department] ([DepatmentID], [DepartmentDescription]) VALUES (3, N'Data warehouse')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID]) VALUES (1, 1, 2, 1, 1, N'Camlin', N'Tate', N'Tatum', CAST(990901 AS Numeric(18, 0)), N'camlintate1@gmail.com', CAST(847965117 AS Numeric(18, 0)), N'Junior Analyst', NULL)
GO
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID]) VALUES (2, 2, 2, 1, 1, N'Mahle', N'Shabalala', NULL, NULL, N'mahleshabalala2@yahoo.com', CAST(718872247 AS Numeric(18, 0)), N'Senior Developer', NULL)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeCalendar] ON 
GO
INSERT [dbo].[EmployeeCalendar] ([EmployeeCalendarID], [EmployeeCalendarLink]) VALUES (1, N'https://stackblitz.com/edit/team-14-bmw-main?devtoolsheight=33&file=app')
GO
SET IDENTITY_INSERT [dbo].[EmployeeCalendar] OFF
GO
SET IDENTITY_INSERT [dbo].[FAQ] ON 
GO
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (1, NULL, N'nmncmxnm')
GO
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (2, N'fdhj', N'fh')
GO
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (3, N'fdhj', N'fh')
GO
SET IDENTITY_INSERT [dbo].[FAQ] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 
GO
INSERT [dbo].[Gender] ([GenderID], [GenderDescription]) VALUES (1, N'Male')
GO
INSERT [dbo].[Gender] ([GenderID], [GenderDescription]) VALUES (2, N'Female')
GO
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[LessonCompletionStatus] ON 
GO
INSERT [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID], [LessonCompletionStatusDescription], [LessonCompletionDate]) VALUES (1, N'Complete', NULL)
GO
INSERT [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID], [LessonCompletionStatusDescription], [LessonCompletionDate]) VALUES (2, N'Incomplete', NULL)
GO
INSERT [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID], [LessonCompletionStatusDescription], [LessonCompletionDate]) VALUES (3, N'In Progress', NULL)
GO
SET IDENTITY_INSERT [dbo].[LessonCompletionStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[LessonContentType] ON 
GO
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (1, N'mp4')
GO
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (2, N'pdf')
GO
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (3, N'doc')
GO
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (4, N'mp3')
GO
SET IDENTITY_INSERT [dbo].[LessonContentType] OFF
GO
SET IDENTITY_INSERT [dbo].[Title] ON 
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (1, N'Miss')
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (2, N'Mr')
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (3, N'Mrs')
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (4, N'Dr')
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (5, N'Ps')
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (6, N'Prof')
GO
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (7, N'Other')
GO
SET IDENTITY_INSERT [dbo].[Title] OFF
GO
ALTER TABLE [dbo].[AchievementType]  WITH CHECK ADD  CONSTRAINT [FK_AchievementType_Badge] FOREIGN KEY([BadgeID])
REFERENCES [dbo].[Badge] ([BadgeID])
GO
ALTER TABLE [dbo].[AchievementType] CHECK CONSTRAINT [FK_AchievementType_Badge]
GO
ALTER TABLE [dbo].[ActiveLog]  WITH CHECK ADD  CONSTRAINT [FK_ActiveLog_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ActiveLog] CHECK CONSTRAINT [FK_ActiveLog_User]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_City]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Country]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Province] FOREIGN KEY([ProvinceID])
REFERENCES [dbo].[Province] ([ProvinceID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Province]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Suburb] FOREIGN KEY([SuburbID])
REFERENCES [dbo].[Suburb] ([SuburbID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Suburb]
GO
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK_AuditLog_User]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Calendar] FOREIGN KEY([EmployeeCalendarID])
REFERENCES [dbo].[EmployeeCalendar] ([EmployeeCalendarID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Calendar]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepatmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([GenderID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Gender]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([TitleID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Title]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentBrand] FOREIGN KEY([EquipmentBrandID])
REFERENCES [dbo].[EquipmentBrand] ([EquipmentBrandID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentBrand]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentTradeInStatus] FOREIGN KEY([EquipmentTradeInStatus])
REFERENCES [dbo].[EquipmentTradeInStatus] ([EquipmentTradeInStatusID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentTradeInStatus]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentType] FOREIGN KEY([EquipmentTypeID])
REFERENCES [dbo].[EquipmentType] ([EquipmentTypeID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentType]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Warranty] FOREIGN KEY([WarrantyID])
REFERENCES [dbo].[Warranty] ([WarrantyID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Warranty]
GO
ALTER TABLE [dbo].[EquipmentQuery]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentQuery_OnboarderEquipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[OnboarderEquipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentQuery] CHECK CONSTRAINT [FK_EquipmentQuery_OnboarderEquipment]
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentQueryStatus._EquipmentQuery] FOREIGN KEY([EquipmentQueryID])
REFERENCES [dbo].[EquipmentQuery] ([EquipmentQueryID])
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.] CHECK CONSTRAINT [FK_EquipmentQueryStatus._EquipmentQuery]
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentQueryStatus._QueryStatus] FOREIGN KEY([EquipmentQueryStatusID])
REFERENCES [dbo].[QueryStatus] ([EquipmentQueryStatusID])
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.] CHECK CONSTRAINT [FK_EquipmentQueryStatus._QueryStatus]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Course]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_LessonCompletionStatus] FOREIGN KEY([LessonCompletionStatusID])
REFERENCES [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_LessonCompletionStatus]
GO
ALTER TABLE [dbo].[LessonContent]  WITH CHECK ADD  CONSTRAINT [FK_LessonContent_ArchiveStatus1] FOREIGN KEY([ArchiveStatusID])
REFERENCES [dbo].[ArchiveStatus] ([ArchiveStatusID])
GO
ALTER TABLE [dbo].[LessonContent] CHECK CONSTRAINT [FK_LessonContent_ArchiveStatus1]
GO
ALTER TABLE [dbo].[LessonContent]  WITH CHECK ADD  CONSTRAINT [FK_LessonContent_LessonContentType] FOREIGN KEY([LessonContenetTypeID])
REFERENCES [dbo].[LessonContentType] ([LessonContentTypeID])
GO
ALTER TABLE [dbo].[LessonContent] CHECK CONSTRAINT [FK_LessonContent_LessonContentType]
GO
ALTER TABLE [dbo].[LessonContent]  WITH CHECK ADD  CONSTRAINT [FK_LessonContent_LessonOutcome] FOREIGN KEY([LessonOutcomeID])
REFERENCES [dbo].[LessonOutcome] ([LessonOutcomeID])
GO
ALTER TABLE [dbo].[LessonContent] CHECK CONSTRAINT [FK_LessonContent_LessonOutcome]
GO
ALTER TABLE [dbo].[LessonOutcome]  WITH CHECK ADD  CONSTRAINT [FK_LessonOutcome_Lesson] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([LessonID])
GO
ALTER TABLE [dbo].[LessonOutcome] CHECK CONSTRAINT [FK_LessonOutcome_Lesson]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Course]
GO
ALTER TABLE [dbo].[Onboarder]  WITH CHECK ADD  CONSTRAINT [FK_Onboarder_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Onboarder] CHECK CONSTRAINT [FK_Onboarder_Employee]
GO
ALTER TABLE [dbo].[OnboarderCourseEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_OnboarderCourseEnrollment_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[OnboarderCourseEnrollment] CHECK CONSTRAINT [FK_OnboarderCourseEnrollment_Course]
GO
ALTER TABLE [dbo].[OnboarderCourseEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_OnboarderCourseEnrollment_Onboarder] FOREIGN KEY([OnboarderID])
REFERENCES [dbo].[Onboarder] ([OnboarderID])
GO
ALTER TABLE [dbo].[OnboarderCourseEnrollment] CHECK CONSTRAINT [FK_OnboarderCourseEnrollment_Onboarder]
GO
ALTER TABLE [dbo].[OnboarderEquipment]  WITH CHECK ADD  CONSTRAINT [FK_OnboarderEquipment_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[OnboarderEquipment] CHECK CONSTRAINT [FK_OnboarderEquipment_Equipment]
GO
ALTER TABLE [dbo].[OnboarderEquipment]  WITH CHECK ADD  CONSTRAINT [FK_OnboarderEquipment_Onboarder] FOREIGN KEY([OnboarderID])
REFERENCES [dbo].[Onboarder] ([OnboarderID])
GO
ALTER TABLE [dbo].[OnboarderEquipment] CHECK CONSTRAINT [FK_OnboarderEquipment_Onboarder]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionCategory] FOREIGN KEY([QuestionCategoryID])
REFERENCES [dbo].[QuestionCategory] ([QuestionCategoryID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionCategory]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Quiz] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quiz] ([QuizID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Quiz]
GO
ALTER TABLE [dbo].[QuestionCategory]  WITH CHECK ADD  CONSTRAINT [FK_QuestionCategory_QuestionBank] FOREIGN KEY([QuestionBankID])
REFERENCES [dbo].[QuestionBank] ([QuestionBankID])
GO
ALTER TABLE [dbo].[QuestionCategory] CHECK CONSTRAINT [FK_QuestionCategory_QuestionBank]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_LessonOutcome] FOREIGN KEY([LessonOutcomeID])
REFERENCES [dbo].[LessonOutcome] ([LessonOutcomeID])
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [FK_Quiz_LessonOutcome]
GO
ALTER TABLE [dbo].[Suburb]  WITH CHECK ADD  CONSTRAINT [FK_Suburb_PostalCode] FOREIGN KEY([PostalCodeID])
REFERENCES [dbo].[PostalCode] ([PostalCodeID])
GO
ALTER TABLE [dbo].[Suburb] CHECK CONSTRAINT [FK_Suburb_PostalCode]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRoleID])
REFERENCES [dbo].[UserRole] ([UserRoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
USE [master]
GO
ALTER DATABASE [INF 370] SET  READ_WRITE 
GO
