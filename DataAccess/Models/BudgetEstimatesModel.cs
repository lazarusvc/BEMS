namespace DataAccessLibrary.Models
{
    public class BudgetEstimatesModel
    {
        public BudgetEstimatesModel(string id, string processing_year, string ministry, string program, string subprog, string account, string project, string sof, string sector, string lastcode, string quantity, string year1_amount, string year2_amount, string year3_amount, string is_by_law, string comment, string sort_position, string version_no, string is_current, string flagged, string flagged_comment, string entered_by, string date_entered, string modified_by, string last_modified, int status_id)
        {
            this.id = id;
            this.processing_year = processing_year;
            this.ministry = ministry;
            this.program = program;
            this.subprog = subprog;
            this.account = account;
            this.project = project;
            this.sof = sof;
            this.sector = sector;
            this.lastcode = lastcode;
            this.quantity = quantity;
            this.year1_amount = year1_amount;
            this.year2_amount = year2_amount;
            this.year3_amount = year3_amount;
            this.is_by_law = is_by_law;
            this.comment = comment;
            this.sort_position = sort_position;
            this.version_no = version_no;
            this.is_current = is_current;
            this.flagged = flagged;
            this.flagged_comment = flagged_comment;
            this.entered_by = entered_by;
            this.date_entered = date_entered;
            this.modified_by = modified_by;
            this.last_modified = last_modified;
            this.status_id = status_id;
        }

      public string id { get; set; }
      public string processing_year { get; set; }
      public string ministry { get; set; }
      public string program { get; set; }
      public string subprog { get; set; }
      public string account { get; set; }
      public string project { get; set; }
      public string sof { get; set; }
      public string sector { get; set; }
      public string lastcode { get; set; }
      public string quantity { get; set; }
      public string year1_amount { get; set; }
      public string year2_amount { get; set; }
      public string year3_amount { get; set; }
      public string is_by_law { get; set; }
      public string comment { get; set; }
      public string sort_position { get; set; }
      public string version_no { get; set; }
      public string is_current { get; set; }
      public string flagged { get; set; }
      public string flagged_comment { get; set; }
      public string entered_by { get; set; }
      public string date_entered { get; set; }
      public string modified_by { get; set; }
      public string last_modified { get; set; }
      public int status_id { get; set; }
    }
}
