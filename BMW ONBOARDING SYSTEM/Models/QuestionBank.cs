using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class QuestionBank
    {
        public QuestionBank()
        {
            QuestionCategory = new HashSet<QuestionCategory>();
        }

        [Key]
        [Column("QuestionBankID")]
        public int QuestionBankId { get; set; }
        [StringLength(50)]
        public string QuestionBankDescription { get; set; }

        [InverseProperty("QuestionBank")]
        public virtual ICollection<QuestionCategory> QuestionCategory { get; set; }
    }
}
