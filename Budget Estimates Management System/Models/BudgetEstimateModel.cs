using System.ComponentModel.DataAnnotations;

namespace Budget_Estimates_Management_System.Models
{
    public class BudgetEstimatesModel
    {

        public int id { get; set; }
        [Required]
        public int processing_year { get; set; }
        [Required]
        [Display(Name ="Ministry")]
        public string ministry { get; set; }
        [Required]
        [Display(Name = "Program")]
        public string program { get; set; }
        [Required]
        [Display(Name = "Sub-Program")]
        public string subprog { get; set; }
        [Required]
        [Display(Name = "Account")]
        public string account { get; set; }
        [Required]
        [Display(Name = "Project")]
        public string project { get; set; }
        [Required]
        [Display(Name = "Source of Funds")]
        public string sof { get; set; }
        [Required]
        [Display(Name = "Sector")]
        public string sector { get; set; }
        public string lastcode { get; set; }
        public string label { get; set; }
        public Int16 quantity { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid figure")]
        public int year0_amount { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid figure")]
        public int year1_amount { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid figure")]
        public int year2_amount { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid figure")]
        public int year3_amount { get; set; }
        [Required]
        public bool is_by_law { get; set; }
        public string comment { get; set; }
        public byte sort_position { get; set; }
        public byte version_no { get; set; }
        public bool is_current { get; set; }
        public bool flagged { get; set; }
        public string flagged_comment { get; set; }
        [Required]
        public string entered_by { get; set; }
        [Required]
        public DateTime date_entered { get; set; }
        public string modified_by { get; set; }
        public DateTime last_modified { get; set; }
        [Required]
        public int entry_status_id { get; set; }
    }
}
