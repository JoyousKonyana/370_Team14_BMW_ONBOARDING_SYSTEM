using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class INF370DBContext : DbContext
    {
        public INF370DBContext()
        {
        }

        public INF370DBContext(DbContextOptions<INF370DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<AchievementType> AchievementType { get; set; }
        public virtual DbSet<ActiveLog> ActiveLog { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ArchiveStatus> ArchiveStatus { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseCompletionStatus> CourseCompletionStatus { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeCalendar> EmployeeCalendar { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentBrand> EquipmentBrand { get; set; }
        public virtual DbSet<EquipmentQuery> EquipmentQuery { get; set; }
        public virtual DbSet<EquipmentQueryStatus> EquipmentQueryStatus { get; set; }
        public virtual DbSet<EquipmentTradeInStatus> EquipmentTradeInStatus { get; set; }
        public virtual DbSet<EquipmentType> EquipmentType { get; set; }
        public virtual DbSet<Faq> Faq { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonCompletionStatus> LessonCompletionStatus { get; set; }
        public virtual DbSet<LessonContent> LessonContent { get; set; }
        public virtual DbSet<LessonContentType> LessonContentType { get; set; }
        public virtual DbSet<LessonOutcome> LessonOutcome { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Onboarder> Onboarder { get; set; }
        public virtual DbSet<OnboarderCourseEnrollment> OnboarderCourseEnrollment { get; set; }
        public virtual DbSet<OnboarderEquipment> OnboarderEquipment { get; set; }
        public virtual DbSet<PostalCode> PostalCode { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<QueryStatus> QueryStatus { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionBank> QuestionBank { get; set; }
        public virtual DbSet<QuestionCategory> QuestionCategory { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Suburb> Suburb { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Warranty> Warranty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=INF 370;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AchievementType>(entity =>
            {
                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.AchievementType)
                    .HasForeignKey(d => d.BadgeId)
                    .HasConstraintName("FK_AchievementType_Badge");
            });

            modelBuilder.Entity<ActiveLog>(entity =>
            {
                entity.Property(e => e.ActiveLogId).ValueGeneratedNever();

                entity.Property(e => e.ActiveLogDeviceIpaddress).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActiveLog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ActiveLog_User");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.StreetName).IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Address_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Address_Country");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_Address_Province");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.SuburbId)
                    .HasConstraintName("FK_Address_Suburb");
            });

            modelBuilder.Entity<ArchiveStatus>(entity =>
            {
                entity.Property(e => e.ArchieveStatusDescription).IsUnicode(false);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.Property(e => e.AuditLogDescription).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditLog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AuditLog_User");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.Property(e => e.BadgeDecription).IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName).IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseDescription).IsUnicode(false);

                entity.Property(e => e.CourseName).IsUnicode(false);
            });

            modelBuilder.Entity<CourseCompletionStatus>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseCompletionStatusDescription).IsUnicode(false);

                entity.Property(e => e.CourseCopletionStatusId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.EmployeeJobTitle).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.EmployeeCalendar)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeCalendarId)
                    .HasConstraintName("FK_Employee_Calendar");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Employee_Gender");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_Employee_Title");
            });

            modelBuilder.Entity<EmployeeCalendar>(entity =>
            {
                entity.Property(e => e.EmployeeCalendarLink).IsUnicode(false);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasOne(d => d.EquipmentBrand)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentBrandId)
                    .HasConstraintName("FK_Equipment_EquipmentBrand");

                entity.HasOne(d => d.EquipmentTradeInStatusNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentTradeInStatus)
                    .HasConstraintName("FK_Equipment_EquipmentTradeInStatus");

                entity.HasOne(d => d.EquipmentType)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentTypeId)
                    .HasConstraintName("FK_Equipment_EquipmentType");

                entity.HasOne(d => d.Warranty)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.WarrantyId)
                    .HasConstraintName("FK_Equipment_Warranty");
            });

            modelBuilder.Entity<EquipmentBrand>(entity =>
            {
                entity.Property(e => e.EquipmentBrandName).IsUnicode(false);
            });

            modelBuilder.Entity<EquipmentQuery>(entity =>
            {
                entity.Property(e => e.EquipmentQueryDescription).IsUnicode(false);

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentQuery)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_EquipmentQuery_OnboarderEquipment");
            });

            modelBuilder.Entity<EquipmentQueryStatus>(entity =>
            {
                entity.Property(e => e.EquipmentQueryStatusId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.EquipmentQuery)
                    .WithMany(p => p.EquipmentQueryStatus)
                    .HasForeignKey(d => d.EquipmentQueryId)
                    .HasConstraintName("FK_EquipmentQueryStatus._EquipmentQuery");

                entity.HasOne(d => d.EquipmentQueryStatusNavigation)
                    .WithOne(p => p.EquipmentQueryStatus)
                    .HasForeignKey<EquipmentQueryStatus>(d => d.EquipmentQueryStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentQueryStatus._QueryStatus");
            });

            modelBuilder.Entity<EquipmentTradeInStatus>(entity =>
            {
                entity.Property(e => e.EquipmentTradeInStatusDescription).IsUnicode(false);
            });

            modelBuilder.Entity<EquipmentType>(entity =>
            {
                entity.Property(e => e.EquipmentTypeDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.Property(e => e.Faqanswer).IsUnicode(false);

                entity.Property(e => e.Faqdescription).IsUnicode(false);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.LessonDescription).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Lesson_Course");

                entity.HasOne(d => d.LessonCompletionStatus)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.LessonCompletionStatusId)
                    .HasConstraintName("FK_Lesson_LessonCompletionStatus");
            });

            modelBuilder.Entity<LessonCompletionStatus>(entity =>
            {
                entity.Property(e => e.LessonCompletionStatusDescription).IsUnicode(false);
            });

            modelBuilder.Entity<LessonContent>(entity =>
            {
                entity.Property(e => e.LessonContent1).IsUnicode(false);

                entity.Property(e => e.LessonContentDescription).IsUnicode(false);

                entity.HasOne(d => d.ArchiveStatus)
                    .WithMany(p => p.LessonContent)
                    .HasForeignKey(d => d.ArchiveStatusId)
                    .HasConstraintName("FK_LessonContent_ArchiveStatus1");

                entity.HasOne(d => d.LessonContenetType)
                    .WithMany(p => p.LessonContent)
                    .HasForeignKey(d => d.LessonContenetTypeId)
                    .HasConstraintName("FK_LessonContent_LessonContentType");

                entity.HasOne(d => d.LessonOutcome)
                    .WithMany(p => p.LessonContent)
                    .HasForeignKey(d => d.LessonOutcomeId)
                    .HasConstraintName("FK_LessonContent_LessonOutcome");
            });

            modelBuilder.Entity<LessonContentType>(entity =>
            {
                entity.Property(e => e.LessonContentDescription).IsUnicode(false);
            });

            modelBuilder.Entity<LessonOutcome>(entity =>
            {
                entity.Property(e => e.LessonOutcomeDescription).IsUnicode(false);

                entity.Property(e => e.LessonOutcomeName).IsUnicode(false);

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonOutcome)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_LessonOutcome_Lesson");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationMessageDescription).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Notification_Course");
            });

            modelBuilder.Entity<Onboarder>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Onboarder)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Onboarder_Employee");
            });

            modelBuilder.Entity<OnboarderCourseEnrollment>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnboarderCourseEnrollment)
                    .HasForeignKey<OnboarderCourseEnrollment>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnboarderCourseEnrollment_Course");

                entity.HasOne(d => d.Onboarder)
                    .WithMany(p => p.OnboarderCourseEnrollment)
                    .HasForeignKey(d => d.OnboarderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnboarderCourseEnrollment_Onboarder");
            });

            modelBuilder.Entity<OnboarderEquipment>(entity =>
            {
                entity.Property(e => e.EquipmentId).ValueGeneratedOnAdd();

                entity.Property(e => e.EquipmentCheckInCondition).IsUnicode(false);

                entity.HasOne(d => d.Equipment)
                    .WithOne(p => p.OnboarderEquipment)
                    .HasForeignKey<OnboarderEquipment>(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnboarderEquipment_Equipment");

                entity.HasOne(d => d.Onboarder)
                    .WithMany(p => p.OnboarderEquipment)
                    .HasForeignKey(d => d.OnboarderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnboarderEquipment_Onboarder");
            });

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.Property(e => e.PostalCode1).IsUnicode(false);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.ProvinceName).IsUnicode(false);
            });

            modelBuilder.Entity<QueryStatus>(entity =>
            {
                entity.Property(e => e.EquipmentQueryDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionAnswer).IsUnicode(false);

                entity.Property(e => e.QuestionDescription).IsUnicode(false);

                entity.HasOne(d => d.QuestionCategory)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuestionCategoryId)
                    .HasConstraintName("FK_Question_QuestionCategory");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_Question_Quiz");
            });

            modelBuilder.Entity<QuestionBank>(entity =>
            {
                entity.Property(e => e.QuestionBankDescription).IsUnicode(false);
            });

            modelBuilder.Entity<QuestionCategory>(entity =>
            {
                entity.Property(e => e.QuestionCategoryDescription).IsUnicode(false);

                entity.HasOne(d => d.QuestionBank)
                    .WithMany(p => p.QuestionCategory)
                    .HasForeignKey(d => d.QuestionBankId)
                    .HasConstraintName("FK_QuestionCategory_QuestionBank");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizDescription).IsUnicode(false);

                entity.Property(e => e.QuizMarkRequirement).IsUnicode(false);

                entity.HasOne(d => d.LessonOutcome)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.LessonOutcomeId)
                    .HasConstraintName("FK_Quiz_LessonOutcome");
            });

            modelBuilder.Entity<Suburb>(entity =>
            {
                entity.Property(e => e.SuburbName).IsUnicode(false);

                entity.HasOne(d => d.PostalCode)
                    .WithMany(p => p.Suburb)
                    .HasForeignKey(d => d.PostalCodeId)
                    .HasConstraintName("FK_Suburb_PostalCode");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleDescription).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleDescription).IsUnicode(false);

                entity.Property(e => e.UserRoleName).IsUnicode(false);
            });

            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.Property(e => e.WarrantyStatus).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
