using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class OnboarderRepository : IOnboarderRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public OnboarderRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }

        public Task<Onboarder> GetOnboarderbyEmpID(int empid)
        {
            IQueryable<Onboarder> border = _inf370ContextDB.Onboarder.
                Where(x => x.EmployeeId == empid);

            return border.FirstOrDefaultAsync();
        }


        public Task<OnboarderCourseEnrollment[]> GetAssignedCourses(int onboarderid)
        {
            IQueryable<OnboarderCourseEnrollment> enrollments = _inf370ContextDB.OnboarderCourseEnrollment.
                Include(x => x.Course).
                Where(x => x.OnboarderId == onboarderid);

            return enrollments.ToArrayAsync();
        }

        public Task<OnboarderCourseEnrollment> GetonboarderByCourseID(int? onboarderid, int? courseID)
        {
            IQueryable<OnboarderCourseEnrollment> enrollments = _inf370ContextDB.OnboarderCourseEnrollment.

                Where(x => x.OnboarderId == onboarderid && x.CourseId == courseID);

            return enrollments.FirstOrDefaultAsync();
        }

        public Task<OnboarderCourseEnrollment> GenerateOnboarderCourseProgress(OnboarderProgressViewModel model)
        {

            // remember to add all table once relationships are corrected in the db
            IQueryable<OnboarderCourseEnrollment> achievements = _inf370ContextDB.OnboarderCourseEnrollment.
                Include(x => x.Course);
            return achievements.FirstOrDefaultAsync();
        }

        public Task<OnboarderCourseEnrollment[]> GenerateAllOnboarderCourseProgress(OnboarderProgressViewModel model)
        {

            // remember to add all table once relationships are corrected in the db
            IQueryable<OnboarderCourseEnrollment> achievements = _inf370ContextDB.OnboarderCourseEnrollment.
                Include(x => x.Course);
            return achievements.ToArrayAsync();
        }

        public Task<Onboarder[]> GetOnboarders()
        {
            IQueryable<Onboarder> onboarders = _inf370ContextDB.Onboarder.Include(x => x.Employee);
            return onboarders.ToArrayAsync();
        }
    }
}
