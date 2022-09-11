using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{

    public class BudgetEstimatesModel
    {

        public int id { get; set; }
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
        public bool is_by_law { get; set; }
        public string comment { get; set; }
        public bool flagged { get; set; }
        [Required]
        public bool is_adjustment { get; set; }
        public string flagged_comment { get; set; }
        public string modified_by { get; set; }
        public DateTime last_modified { get; set; }
        public Int16 entry_status_id { get; set; }
    }
}
