using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Profiles
{
    public class CourseProfile : Profile
    {

        public CourseProfile()
        {
            this.CreateMap<Course, CourseViewModel>()
                .ReverseMap();


            this.CreateMap<LessonOutcome, LessonOutcomeViewModel>().
                ReverseMap();


            this.CreateMap<AchievementType, AchievementTypeViewModel>().
                ReverseMap();

         


            this.CreateMap<LessonContent, LessonContentViewModel>().
                ReverseMap();

            this.CreateMap<Lesson, LessonViewModel>().
               ReverseMap();

            this.CreateMap<EmployeeCalendar, EmployeeCalendarViewModel>().
               ReverseMap();

            this.CreateMap<Quiz, QuizViewModel>().
            ReverseMap();

            this.CreateMap<Employee, EmployeeViewModel>().
            ReverseMap();


            this.CreateMap<OnboarderCourseEnrollment, OnboarderCourseEnrollmentViewModel>().
            ReverseMap();

            this.CreateMap<Question, QuestionViewModel>().
            ReverseMap();


            this.CreateMap<User, CreateUserViewModel>().
            ReverseMap();

            this.CreateMap<Achievement, AchievementViewModel>().
           ReverseMap();

            this.CreateMap<UserRole, UserRoleViewModel>().
            ReverseMap();


            this.CreateMap<Equipment, EquipmentViewModel>().
             ReverseMap();

            this.CreateMap<OnboarderEquipment, AssignedEquipmentViewModel>().
             ReverseMap();


            this.CreateMap<EquipmentQuery, EquipmentQueryViewModelcs>().
            ReverseMap();

            this.CreateMap<EquipmentQueryStatus, ResolveQueryViewModel>().
            ReverseMap();

            this.CreateMap<OnboarderEquipment, EquipmentCheckOutViewModel>().
            ReverseMap();


            this.CreateMap<Faq, FaqViewModel>().
            ReverseMap();

            this.CreateMap<EmployeeViewModel, CreateAuditLogViewModel>().
             ReverseMap();

            this.CreateMap<AuditLog, CreateAuditLogViewModel>().
            ReverseMap();

            this.CreateMap<CreateAuditLogViewModel, AuditLog>().
             ReverseMap();

            this.CreateMap<CreateAuditLogViewModel, EquipmentViewModel>().
            ReverseMap();

            this.CreateMap<Notification, NotificationViewModel>().
           ReverseMap();

            this.CreateMap<Warranty, WarrantyViewModel>().
             ReverseMap();

            this.CreateMap<Province, ProvinceViewModel>().
            ReverseMap();
            this.CreateMap<Country, CountryViewModel>().
            ReverseMap();
            this.CreateMap<City, CityViewModel>().
            ReverseMap();
            this.CreateMap<Suburb, SuburbViewModel>().
           ReverseMap();

            this.CreateMap<PostalCode, PostalCodeViewModel>().
         ReverseMap();


            this.CreateMap<Address, EmployeeViewModel>().
         ReverseMap();
        }
    }
}



