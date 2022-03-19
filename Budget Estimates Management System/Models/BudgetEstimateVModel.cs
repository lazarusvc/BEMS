using System.ComponentModel.DataAnnotations;

namespace Budget_Estimates_Management_System.Models
{
    public class BudgetEstimateVModel
    {

        [Required]
        [Range(2020, 3000, ErrorMessage = "Please enter year")]
        public int processing_year { get; set; }
        [Required]
        [Display(Name = "Ministry")]
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
        [Display(Name = "Project")]
        public string project { get; set; }
        [Display(Name = "Source of Funds")]
        public string sof { get; set; }
        [Display(Name = "Sector")]
        public string sector { get; set; }
        public string lastcode { get; set; }
        public string label { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage = "Please enter valid figure")]
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
        public bool flagged { get; set; }
        public string flagged_comment { get; set; }
        [Required]
        public string modified_by { get; set; }
        public DateTime last_modified { get; set; }
        [Required]
        public int entry_status_id { get; set; }
    }
}
