namespace DataAccessLibrary.Models
{

    public class BudgetEstimatesModel
    {

        public int id { get; set; }
        public int processing_year { get; set; }
        public string ministry { get; set; }
        public string program { get; set; }
        public string subprog { get; set; }
        public string account { get; set; }
        public string project { get; set; }
        public string sof { get; set; }
        public string sector { get; set; }
        public string lastcode { get; set; }
        public string label { get; set; }
        public Int16 quantity { get; set; }
        public int year0_amount { get; set; }
        public int year1_amount { get; set; }
        public int year2_amount { get; set; }
        public int year3_amount { get; set; }
        public bool is_by_law { get; set; }
        public string comment { get; set; }
        public byte sort_position { get; set; }
        public byte version_no { get; set; }
        public bool is_current { get; set; }
        public bool flagged { get; set; }
        public string flagged_comment { get; set; }
        public string entered_by { get; set; }
        public DateTime date_entered { get; set; }
        public string modified_by { get; set; }
        public DateTime last_modified { get; set; }
        public int entry_status_id { get; set; }
    }
}
