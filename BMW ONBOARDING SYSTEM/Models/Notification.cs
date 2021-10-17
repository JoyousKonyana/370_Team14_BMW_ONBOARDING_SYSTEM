using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Notification
    {
        [Key]
        [Column("NotificationID")]
        public int NotificationId { get; set; }
        [Column("NotificationTypeID")]
        public int? NotificationTypeId { get; set; }
        [StringLength(50)]
        public string NotificationMessageDescription { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
    }
}
