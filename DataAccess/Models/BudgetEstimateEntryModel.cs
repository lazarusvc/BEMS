using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class BudgetEstimateEntryModel : BudgetEstimatesModel
    {
        public BudgetEstimateEntryModel(string soc, string ministryName, string programName,string subprogName, string socName,string accountName, string sectorName, string projectName, int year0, string id, string processing_year, string ministry, string program, string subprog, string account, string project, string sof, string sector, string lastcode, string label, int quantity, string year0_amount, string year1_amount, string year2_amount, string year3_amount, string is_by_law, string comment, string sort_position, string version_no, string is_current, string flagged, string flagged_comment, string entered_by, string date_entered, string modified_by, string last_modified, int status_id) : base(id, processing_year, ministry, program, subprog, account, project, sof, sector, lastcode, label, quantity, year0_amount, year1_amount, year2_amount, year3_amount, is_by_law, comment, sort_position, version_no, is_current, flagged, flagged_comment, entered_by, date_entered, modified_by, last_modified, status_id)
        {            
            this.ministryName =ministryName;
            this.programName = programName;
            this.subprogName = subprogName;
            this.socName = socName;
            this.accountName = accountName;
            this.projectName = projectName;
            this.sectorName = sectorName;
            this.soc= soc;
        }
        
        public string ministryName { get; set; }
        public string programName { get; set; }
        public string subprogName { get; set; }
        public string soc { get; set; }
        public string socName { get; set; }
        public string accountName { get; set; }
        public string projectName { get; set; }
        public string sectorName { get; set; }

    }


}
