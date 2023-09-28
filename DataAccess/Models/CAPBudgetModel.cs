using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{

    public class CAPBudgetModel
    {

        public int id { get; set; }

        public string ldr_entity_id { get; set; } = "";

        [Required]
        [Range(2020, 3000, ErrorMessage = "Please enter year")]
        public int processing_year { get; set; }

        [Required]
        [Display(Name = "Ministry")]

        public string ministry { get; set; } = "";
        [Required]
        [Display(Name = "Program")]
        public string program { get; set; } = "";

        [Required]
        [Display(Name = "Sub-Program")]
        public string subprog { get; set; } = "";


        [Display(Name = "Account")]
        public string account { get; set; } = "";

        [Display(Name = "Project")]
        public string project { get; set; } = "";

        [Display(Name = "Source of Funds")]
        public string sof { get; set; } = "";

        [Display(Name = "Sector")]
        public string sector { get; set; } = "";

        public string lastcode { get; set; } = "";
        public string curr_code { get; set; } = "";

        public string Name { get; set; } = "";
        public string Name2 { get; set; } = "";

        public string ldr_amt_0 { get; set; } = "";

        public string ldr_amt_1 { get; set; } = "";

        public string Expr1000 { get; set; } = "";

        public string Expr1001 { get; set; } = "";

        public string Expr1002 { get; set; } = "";

        public string Expr1003 { get; set; } = "";

        public string Expr1004 { get; set; } = "";

        public string Expr1005 { get; set; } = "";

        public string Expr1006 { get; set; } = "";

        public string Expr1007 { get; set; } = "";

        public string Expr1008 { get; set; } = "";

        public string Expr1009 { get; set; } = "";

        public string Expr1010 { get; set; } = "";

        public string Expr1011 { get; set; } = "";

        public string Expr1012 { get; set; } = "";

        public string Expr1013 { get; set; } = "";


    }
}
