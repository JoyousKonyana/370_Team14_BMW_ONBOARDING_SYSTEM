using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class QuestionCategory
    {
        [Key]
        [Column("QuestionCategoryID")]
        public int QuestionCategoryId { get; set; }
        [Column("QuestionBankID")]
        public int? QuestionBankId { get; set; }
        [StringLength(50)]
        public string QuestionCategoryDescription { get; set; }
    }
}
