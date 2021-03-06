USE [master]
GO
/****** Object:  Database [INF 370]    Script Date: 2021/10/09 11:31:53 ******/
CREATE DATABASE [INF 3702]
 go

USE [INF 3702]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Achievement]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievement](
	[AchievementID] [int] IDENTITY(1,1) NOT NULL,
	[AchievementDate] [datetime] NULL,
	[AchievementTypeID] [int] NULL,
	[OnboarderID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[QuizID] [int] NULL,
	[MarkAchieved] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Achievement] PRIMARY KEY CLUSTERED 
(
	[AchievementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AchievementType]    Script Date: 2021/10/09 11:31:54 ******/
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
/****** Object:  Table [dbo].[ActiveLog]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[SuburbID] [int] NULL,
	[ProvinceID] [int] NULL,
	[CityID] [int] NULL,
	[CountryID] [int] NULL,
	[StreetNumber] [nvarchar](max) NULL,
	[StreetName] [varchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArchiveStatus]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Badge]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseCompletionStatus]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseCompletionStatus](
	[CourseCopletionStatusID] [int] IDENTITY(1,1) NOT NULL,
	[OnboarderID] [int] NULL,
	[CourseID] [int] NULL,
	[CourseCompletionStatusDescription] [varchar](50) NULL,
	[CourseCompletionStatusDate] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[UserID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeCalendar]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 2021/10/09 11:31:54 ******/
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
/****** Object:  Table [dbo].[EquipmentBrand]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EquipmentQuery]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EquipmentQuery](
	[EquipmentQueryID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[OnboarderID] [int] NULL,
	[EquipmentQueryDescription] [varchar](max) NULL,
	[EquipmentQueryDate] [datetime] NULL,
 CONSTRAINT [PK_EquipmentQuery] PRIMARY KEY CLUSTERED 
(
	[EquipmentQueryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EquipmentQueryStatus.]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentQueryStatus.](
	[EquipmentQueryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentQueryID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentQueryStatus.] PRIMARY KEY CLUSTERED 
(
	[EquipmentQueryStatusID] ASC,
	[EquipmentQueryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTradeInStatus]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lesson](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NULL,
	[LessonCompletionStatusID] [int] NULL,
	[LessonDescription] [varchar](50) NULL,
	[LessonName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LessonCompletionStatus]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LessonContent]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LessonContent](
	[LessonConentID] [int] IDENTITY(1,1) NOT NULL,
	[LessonContenetTypeID] [int] NULL,
	[LessonOutcomeID] [int] NULL,
	[ArchiveStatusID] [int] NULL,
	[LessonContentDescription] [varchar](50) NULL,
	[LessonContent] [varchar](max) NULL,
	[LessonDocs] [varbinary](max) NULL,
 CONSTRAINT [PK_LessonContent] PRIMARY KEY CLUSTERED 
(
	[LessonConentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LessonContentType]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LessonOutcome]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Onboarder]    Script Date: 2021/10/09 11:31:54 ******/
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
/****** Object:  Table [dbo].[OnboarderCourseEnrollment]    Script Date: 2021/10/09 11:31:54 ******/
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
	[OnboarderID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OnboarderEquipment]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OnboarderEquipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[OnboarderID] [int] NOT NULL,
	[EquipmentCheckOutDate] [datetime] NULL,
	[EquipmentCheckInDate] [datetime] NULL,
	[EquipmentCheckInCondition] [varchar](50) NULL,
 CONSTRAINT [PK_OnboarderEquipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC,
	[OnboarderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Option]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Option](
	[OptionID] [int] NOT NULL,
	[OptionNO] [numeric](18, 0) NULL,
	[OptionDescription] [varchar](50) NULL,
	[QuestionID] [int] NULL,
 CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED 
(
	[OptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OTP]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OTP](
	[OTP_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[OtpValue] [varchar](50) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_OTP] PRIMARY KEY CLUSTERED 
(
	[OTP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PostalCode]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Province]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QueryStatus]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionCategory]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Suburb]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Title]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](max) NULL,
	[EmployeeID] [int] NULL,
	[UserRoleID] [int] NULL,
	[UserImg] [image] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Warranty]    Script Date: 2021/10/09 11:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210911072745_Changed streetnumber from decimal to int', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210911072954_decimal to int', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210911073123_changed to decimal', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210911073214_changed street number to int', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210911073459_street number to string', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210917164109_new code', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210917173352_changed otm name', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210917173731_added value', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210917185532_changed property', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210927140314_changed lessonname to byte', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210927140909_lessonname to byte', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210927141121_lessonname to string', N'3.1.0')
SET IDENTITY_INSERT [dbo].[Achievement] ON 

INSERT [dbo].[Achievement] ([AchievementID], [AchievementDate], [AchievementTypeID], [OnboarderID], [CourseID], [QuizID], [MarkAchieved]) VALUES (1, NULL, 3, 1, 1, 1, CAST(95 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Achievement] OFF
SET IDENTITY_INSERT [dbo].[AchievementType] ON 

INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (3, N'Gold', NULL)
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (4, NULL, NULL)
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (5, N'dsf', 1)
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (6, N'bmbmn', 1)
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (7, N'123', 2)
INSERT [dbo].[AchievementType] ([AchievementTypeID], [AchievementTypeDescription], [BadgeID]) VALUES (8, N'123', 4)
SET IDENTITY_INSERT [dbo].[AchievementType] OFF
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (3, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (4, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (5, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (6, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (7, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (8, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (9, 1, 1, 1, 1, N'12345', N'Burnet street')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (11, 1, 1, 1, 1, N'132', N'123456')
INSERT [dbo].[Address] ([AddressID], [SuburbID], [ProvinceID], [CityID], [CountryID], [StreetNumber], [StreetName]) VALUES (12, 1, 1, 1, 1, N'132', N'123456')
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[ArchiveStatus] ON 

INSERT [dbo].[ArchiveStatus] ([ArchiveStatusID], [ArchieveStatusDescription]) VALUES (1, N'Archived')
INSERT [dbo].[ArchiveStatus] ([ArchiveStatusID], [ArchieveStatusDescription]) VALUES (2, N'Unarchived')
SET IDENTITY_INSERT [dbo].[ArchiveStatus] OFF
SET IDENTITY_INSERT [dbo].[Badge] ON 

INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (1, N'Bronze')
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (2, N'Silver')
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (3, N'Gold')
INSERT [dbo].[Badge] ([BadgeID], [BadgeDecription]) VALUES (4, N'Platinum')
SET IDENTITY_INSERT [dbo].[Badge] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityID], [Country]) VALUES (1, N'South Africa')
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [CountryName]) VALUES (1, N'South africa')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (2, N'This course introduces', CAST(N'2018-01-03 00:00:00.000' AS DateTime), N'2018-01-03')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (3, N'This course introduces', CAST(N'2018-01-03 00:00:00.000' AS DateTime), N'Basics')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (4, N'This course introduces', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'INF 354')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (5, N'THIS IS 354', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Basicsa')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (6, N'THIS IS 354', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Basicsa')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (7, N'THIS IS 354', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Basicsa')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (8, N'THIS IS 354', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Super User')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (10, N'nbvbn', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Super User')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (11, N'This course introduces', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'BASICA')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (12, N'this is obs 3302', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'obs 330')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (14, N'This course introduces', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'OBS 310')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (15, N'THIS IS 354', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'OBS 310')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (16, N'this is Testing 1010', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Testing 101')
INSERT [dbo].[Course] ([CourseID], [CourseDescription], [CourseDueDate], [CourseName]) VALUES (17, N'this is Testing 101', CAST(N'2013-03-04 00:00:00.000' AS DateTime), N'Testing 101')
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseCompletionStatus] ON 

INSERT [dbo].[CourseCompletionStatus] ([CourseCopletionStatusID], [OnboarderID], [CourseID], [CourseCompletionStatusDescription], [CourseCompletionStatusDate]) VALUES (1, 1, 1, N'Complete', NULL)
INSERT [dbo].[CourseCompletionStatus] ([CourseCopletionStatusID], [OnboarderID], [CourseID], [CourseCompletionStatusDescription], [CourseCompletionStatusDate]) VALUES (1, 2, 1, N'Incomplete', NULL)
INSERT [dbo].[CourseCompletionStatus] ([CourseCopletionStatusID], [OnboarderID], [CourseID], [CourseCompletionStatusDescription], [CourseCompletionStatusDate]) VALUES (1, 1, 1, N'Complete', NULL)
INSERT [dbo].[CourseCompletionStatus] ([CourseCopletionStatusID], [OnboarderID], [CourseID], [CourseCompletionStatusDescription], [CourseCompletionStatusDate]) VALUES (1, 2, 1, N'Incomplete', NULL)
SET IDENTITY_INSERT [dbo].[CourseCompletionStatus] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepatmentID], [DepartmentDescription]) VALUES (1, N'Analytics')
INSERT [dbo].[Department] ([DepatmentID], [DepartmentDescription]) VALUES (2, N'Development')
INSERT [dbo].[Department] ([DepatmentID], [DepartmentDescription]) VALUES (3, N'Data warehouse')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (1, 1, 2, 1, 1, N'Camlin', N'Tate', N'Tatum', CAST(990901 AS Numeric(18, 0)), N'camlintate1@gmail.com', CAST(847965117 AS Numeric(18, 0)), N'Junior Analyst', NULL, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (2, 2, 2, 1, 1, N'Mahle', N'Shabalala', NULL, NULL, N'mahleshabalala2@yahoo.com', CAST(718872247 AS Numeric(18, 0)), N'Senior Developer', NULL, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (3, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(324134225646 AS Numeric(18, 0)), N'konyanajoyous2@gmail.com', CAST(899766534 AS Numeric(18, 0)), N'1', 1, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (4, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(324134225646 AS Numeric(18, 0)), N'konyanajoyous2@gmail.com', CAST(899766534 AS Numeric(18, 0)), N'1', 1, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (5, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(324134225646 AS Numeric(18, 0)), N'konyanajoyous2@gmail.com', CAST(899766534 AS Numeric(18, 0)), N'1', 1, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (6, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(324134225646 AS Numeric(18, 0)), N'konyanajoyous2@gmail.com', CAST(899766534 AS Numeric(18, 0)), N'1', 1, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (7, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(324134225646 AS Numeric(18, 0)), N'konyanajoyous2@gmail.com', CAST(899766534 AS Numeric(18, 0)), N'1', 1, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (8, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(324134225646 AS Numeric(18, 0)), N'konyanajoyous2@gmail.com', CAST(899766534 AS Numeric(18, 0)), N'1', 1, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (9, NULL, 1, NULL, NULL, N'INF', N'354', N'hbnb', CAST(90909080 AS Numeric(18, 0)), N'string', CAST(1 AS Numeric(18, 0)), NULL, 4, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [DepartmentID], [GenderID], [AddressID], [EmployeeCalendarID], [FirstName], [LastName], [MiddleName], [IDNumber], [EmailAddress], [ContactNumber], [EmployeeJobTitle], [TitleID], [UserID]) VALUES (10, NULL, 1, NULL, NULL, N'INF', N'nbmnb', N'hbnb', CAST(90909080 AS Numeric(18, 0)), N'string', CAST(1 AS Numeric(18, 0)), NULL, 3, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeCalendar] ON 

INSERT [dbo].[EmployeeCalendar] ([EmployeeCalendarID], [EmployeeCalendarLink]) VALUES (1, N'https://stackblitz.com/edit/team-14-bmw-main?devtoolsheight=33&file=app')
SET IDENTITY_INSERT [dbo].[EmployeeCalendar] OFF
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentTypeID], [EquipmentTradeInStatus], [WarrantyID], [EquipmentBrandID], [EquipmentTradeUnDeadline], [EquipmentSerialNumber]) VALUES (6, 1, 1, 1, 1, CAST(N'2018-03-02 00:00:00.000' AS DateTime), CAST(4544646 AS Numeric(18, 0)))
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentTypeID], [EquipmentTradeInStatus], [WarrantyID], [EquipmentBrandID], [EquipmentTradeUnDeadline], [EquipmentSerialNumber]) VALUES (7, 1, 1, 1, 1, CAST(N'2018-03-02 00:00:00.000' AS DateTime), CAST(4544646 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Equipment] OFF
SET IDENTITY_INSERT [dbo].[EquipmentBrand] ON 

INSERT [dbo].[EquipmentBrand] ([EquipmentBrandID], [EquipmentBrandName]) VALUES (1, N'Hp')
SET IDENTITY_INSERT [dbo].[EquipmentBrand] OFF
SET IDENTITY_INSERT [dbo].[EquipmentTradeInStatus] ON 

INSERT [dbo].[EquipmentTradeInStatus] ([EquipmentTradeInStatusID], [EquipmentTradeInStatusDescription]) VALUES (1, N'Traded-in')
INSERT [dbo].[EquipmentTradeInStatus] ([EquipmentTradeInStatusID], [EquipmentTradeInStatusDescription]) VALUES (2, N'Not Traded-in')
SET IDENTITY_INSERT [dbo].[EquipmentTradeInStatus] OFF
SET IDENTITY_INSERT [dbo].[EquipmentType] ON 

INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeDescription]) VALUES (1, N'Laptop')
SET IDENTITY_INSERT [dbo].[EquipmentType] OFF
SET IDENTITY_INSERT [dbo].[FAQ] ON 

INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (17, N'Who is our admin', N'xzcxzc')
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (18, N'When are courses due after date of assignedment', N'Never')
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (19, N'When are courses due after date of assignedment', N'2 weeks')
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (20, N'When are courses due after date of assignedment', N'2 weeks')
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (21, N'When are courses due after date of assignedment', N'Never')
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (23, N'When are courses due after date of assignedment', N'2 weeks')
INSERT [dbo].[FAQ] ([FAQID], [FAQDescription], [FAQAnswer]) VALUES (24, N'cnmcbc', N'x')
SET IDENTITY_INSERT [dbo].[FAQ] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([GenderID], [GenderDescription]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([GenderID], [GenderDescription]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([LessonID], [CourseID], [LessonCompletionStatusID], [LessonDescription], [LessonName]) VALUES (12, 2, 1, N'This course introduces', N'Super User1')
INSERT [dbo].[Lesson] ([LessonID], [CourseID], [LessonCompletionStatusID], [LessonDescription], [LessonName]) VALUES (13, 2, 1, N'THIS IS 354', N'OBS 310')
INSERT [dbo].[Lesson] ([LessonID], [CourseID], [LessonCompletionStatusID], [LessonDescription], [LessonName]) VALUES (14, 2, 1, N'THIS IS 354', N'OBS 310')
INSERT [dbo].[Lesson] ([LessonID], [CourseID], [LessonCompletionStatusID], [LessonDescription], [LessonName]) VALUES (15, 2, 1, N'i am lesson one', N'lesson one')
INSERT [dbo].[Lesson] ([LessonID], [CourseID], [LessonCompletionStatusID], [LessonDescription], [LessonName]) VALUES (16, 2, 1, N'this is Testing 101', N'Testing 1010')
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[LessonCompletionStatus] ON 

INSERT [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID], [LessonCompletionStatusDescription], [LessonCompletionDate]) VALUES (1, N'Complete', NULL)
INSERT [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID], [LessonCompletionStatusDescription], [LessonCompletionDate]) VALUES (2, N'Incomplete', NULL)
INSERT [dbo].[LessonCompletionStatus] ([LessonCompletionStatusID], [LessonCompletionStatusDescription], [LessonCompletionDate]) VALUES (3, N'In Progress', NULL)
SET IDENTITY_INSERT [dbo].[LessonCompletionStatus] OFF
SET IDENTITY_INSERT [dbo].[LessonContentType] ON 

INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (1, N'mp4')
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (2, N'pdf')
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (3, N'doc')
INSERT [dbo].[LessonContentType] ([LessonContentTypeID], [LessonContentDescription]) VALUES (4, N'mp3')
SET IDENTITY_INSERT [dbo].[LessonContentType] OFF
SET IDENTITY_INSERT [dbo].[LessonOutcome] ON 

INSERT [dbo].[LessonOutcome] ([LessonOutcomeID], [LessonID], [LessonOutcomeDescription], [LessonOutcomeName]) VALUES (4, 15, N'nbvnbtryt77', N'OBS 310')
INSERT [dbo].[LessonOutcome] ([LessonOutcomeID], [LessonID], [LessonOutcomeDescription], [LessonOutcomeName]) VALUES (5, NULL, N'nbvnb', N'Super User')
SET IDENTITY_INSERT [dbo].[LessonOutcome] OFF
SET IDENTITY_INSERT [dbo].[Onboarder] ON 

INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (1, 1)
INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (2, 3)
INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (3, 5)
INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (4, 6)
INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (5, 8)
INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (6, 9)
INSERT [dbo].[Onboarder] ([OnboarderID], [EmployeeID]) VALUES (7, 10)
SET IDENTITY_INSERT [dbo].[Onboarder] OFF
SET IDENTITY_INSERT [dbo].[OTP] ON 

INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (1, 1, N'12344', CAST(N'2020-02-01 00:00:00.000' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (2, 1, N'12344', CAST(N'2020-02-01 00:00:00.000' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (3, 1, N'12344', CAST(N'2020-02-01 00:00:00.000' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (4, 2, N'442829', CAST(N'2021-09-18 09:05:58.627' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (5, 2, N'323933', CAST(N'2021-09-18 09:14:43.833' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (6, 1, N'444444', CAST(N'2020-01-03 00:00:00.000' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (7, 1, N'444444', CAST(N'2021-11-11 00:00:00.000' AS DateTime))
INSERT [dbo].[OTP] ([OTP_ID], [User_ID], [OtpValue], [Timestamp]) VALUES (8, 2, N'794255', CAST(N'2021-09-20 11:39:02.310' AS DateTime))
SET IDENTITY_INSERT [dbo].[OTP] OFF
SET IDENTITY_INSERT [dbo].[PostalCode] ON 

INSERT [dbo].[PostalCode] ([PostalCodeID], [PostalCode]) VALUES (1, N'0122')
SET IDENTITY_INSERT [dbo].[PostalCode] OFF
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([ProvinceID], [ProvinceName]) VALUES (1, N'Gauteng')
INSERT [dbo].[Province] ([ProvinceID], [ProvinceName]) VALUES (2, N'Gauteng')
SET IDENTITY_INSERT [dbo].[Province] OFF
SET IDENTITY_INSERT [dbo].[Suburb] ON 

INSERT [dbo].[Suburb] ([SuburbID], [PostalCodeID], [SuburbName]) VALUES (1, 1, N'pta')
SET IDENTITY_INSERT [dbo].[Suburb] OFF
SET IDENTITY_INSERT [dbo].[Title] ON 

INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (1, N'Miss')
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (2, N'Mr')
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (3, N'Mrs')
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (4, N'Dr')
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (5, N'Ps')
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (6, N'Prof')
INSERT [dbo].[Title] ([TitleID], [TitleDescription]) VALUES (7, N'Other')
SET IDENTITY_INSERT [dbo].[Title] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [Username], [Password], [EmployeeID], [UserRoleID], [UserImg]) VALUES (1, N'konyanajoyous2@gmail.com', N'EjL8xI+97dFn9KPLxX7m+uQDGCE=', 0, 1, NULL)
INSERT [dbo].[User] ([UserID], [Username], [Password], [EmployeeID], [UserRoleID], [UserImg]) VALUES (2, N'konyanajoyous2@gmail.com', N'RBGun9S19LgFPtF9tGhSPLp0q80=', 8, 1, NULL)
INSERT [dbo].[User] ([UserID], [Username], [Password], [EmployeeID], [UserRoleID], [UserImg]) VALUES (3, N'string', N'L0DM6hbwdclhBmaK1cvXLgF6a6A=', 9, 1, NULL)
INSERT [dbo].[User] ([UserID], [Username], [Password], [EmployeeID], [UserRoleID], [UserImg]) VALUES (4, N'string', N'uIrZ2cGm5hmbS1AxnYMo0a1ZHpA=', 10, 1, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (1, N'This descrption', N'onboarder')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (2, NULL, N'SuperUser')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (3, NULL, N'SuperUser')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (4, NULL, N'SuperUser')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (5, NULL, N'SuperUser')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (7, NULL, N'Super User')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (8, NULL, N'Super User')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (9, NULL, N'Super User')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (10, NULL, N'INF 354')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (11, N'THIS IS 354', N'INF 354')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (14, N'sd', N'BASICA')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (15, N'sd', N'OBS 310')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (16, N'This is a super user', N'Super User')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (17, N'This course introduces', N'Super User')
INSERT [dbo].[UserRole] ([UserRoleID], [UserRoleDescription], [UserRoleName]) VALUES (18, N'this is a super user', N'Super user')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[Warranty] ON 

INSERT [dbo].[Warranty] ([WarrantyID], [WarrantyStartDate], [WarrantyENdDate], [WarrantyStatus]) VALUES (1, CAST(N'2021-01-03 00:00:00.000' AS DateTime), CAST(N'2021-01-03 00:00:00.000' AS DateTime), N'Good')
SET IDENTITY_INSERT [dbo].[Warranty] OFF
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
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_User]
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
ALTER TABLE [dbo].[EquipmentQueryStatus.]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentQueryStatus._EquipmentQuery1] FOREIGN KEY([EquipmentQueryID])
REFERENCES [dbo].[EquipmentQuery] ([EquipmentQueryID])
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.] CHECK CONSTRAINT [FK_EquipmentQueryStatus._EquipmentQuery1]
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentQueryStatus._QueryStatus1] FOREIGN KEY([EquipmentQueryStatusID])
REFERENCES [dbo].[QueryStatus] ([EquipmentQueryStatusID])
GO
ALTER TABLE [dbo].[EquipmentQueryStatus.] CHECK CONSTRAINT [FK_EquipmentQueryStatus._QueryStatus1]
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
ALTER TABLE [dbo].[OnboarderEquipment]  WITH CHECK ADD  CONSTRAINT [FK_OnboarderEquipment_EquipmentQuery] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[EquipmentQuery] ([EquipmentQueryID])
GO
ALTER TABLE [dbo].[OnboarderEquipment] CHECK CONSTRAINT [FK_OnboarderEquipment_EquipmentQuery]
GO
ALTER TABLE [dbo].[OnboarderEquipment]  WITH CHECK ADD  CONSTRAINT [FK_OnboarderEquipment_Onboarder] FOREIGN KEY([OnboarderID])
REFERENCES [dbo].[Onboarder] ([OnboarderID])
GO
ALTER TABLE [dbo].[OnboarderEquipment] CHECK CONSTRAINT [FK_OnboarderEquipment_Onboarder]
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Option_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Option_Question]
GO
ALTER TABLE [dbo].[OTP]  WITH CHECK ADD  CONSTRAINT [FK_OTP_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[OTP] CHECK CONSTRAINT [FK_OTP_User]
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
