using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Option
    {
        [Key]
        [Column("OptionID")]
        public int OptionId { get; set; }
        [Column("OptionNO", TypeName = "numeric(18, 0)")]
        public decimal? OptionNo { get; set; }
        [StringLength(50)]
        public string OptionDescription { get; set; }
        [Column("QuestionID")]
        public int? QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty("Option")]
        public virtual Question Question { get; set; }
    }
}
