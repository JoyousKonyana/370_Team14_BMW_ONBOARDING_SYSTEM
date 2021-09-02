using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class OnboarderCourseEnrollmentViewModel
    {
        public int OnboarderId { get; set; }
        public int CourseId { get; set; }
        public DateTime? OnboarderEnrollmentDate { get; set; }
    }
}
