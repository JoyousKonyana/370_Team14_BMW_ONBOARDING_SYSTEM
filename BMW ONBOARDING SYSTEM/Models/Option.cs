using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Option
    {
        [Key]
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        [InverseProperty("Option")]
        public virtual Question Question { get; set; }
        public int OptionNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string OptionDescription { get; set; }
    }
}
