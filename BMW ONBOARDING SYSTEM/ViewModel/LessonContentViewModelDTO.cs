using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class LessonContentViewModelDTO
    {
        public int? LessonContenetTypeId { get; set; }
        public int? LessonId { get; set; }
        public int? ArchiveStatusId { get; set; }
        public string LessonContentDescription { get; set; }

        public IFormFile LessonContentBytes { get; set; }
    }
}
