using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IOnboarderRepository
    {
        Task<Onboarder> GetOnboarderbyEmpID(int empid);
        Task<OnboarderCourseEnrollment[]> GetAssignedCourses(int onboarderid);
        Task<OnboarderCourseEnrollment> GetonboarderByCourseID(int? onboarderid, int? courseID);
        Task<OnboarderCourseEnrollment> GenerateOnboarderCourseProgress(OnboarderProgressViewModel model);
        Task<OnboarderCourseEnrollment[]> GenerateAllOnboarderCourseProgress(OnboarderProgressViewModel model);
        Task<Onboarder[]> GetOnboarders();

    }
}
