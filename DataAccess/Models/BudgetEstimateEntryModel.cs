using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class BudgetEstimateEntryModel 
    {
        public BudgetEstimateEntryModel(List<BudgetEstimateEntryModelDetail> budgetsSubmissions, List<StartingEstimatesModel> startingEstimates)
        {
            BudgetsSubmissions = budgetsSubmissions;
            StartingEstimates = startingEstimates;
        }

        public List<BudgetEstimateEntryModelDetail> BudgetsSubmissions { get; set; }

        public List<StartingEstimatesModel> StartingEstimates { get; set; }
    }

    public class BudgetEstimateEntryModelDetail : BudgetEstimatesModel
    {
        public BudgetEstimateEntryModelDetail(string ministryName, string programName,string subprogramName, string socName,string accountName,string projectName, string id, string processing_year, string ministry, string program, string subprog, string account, string project, string sof, string sector, string lastcode, string quantity, string year1_amount, string year2_amount, string year3_amount, string is_by_law, string comment, string sort_position, string version_no, string is_current, string flagged, string flagged_comment, string entered_by, string date_entered, string modified_by, string last_modified, int status_id) : base(id, processing_year, ministry, program, subprog, account, project, sof, sector, lastcode, quantity, year1_amount, year2_amount, year3_amount, is_by_law, comment, sort_position, version_no, is_current, flagged, flagged_comment, entered_by, date_entered, modified_by, last_modified, status_id)
        {            
            this.ministryName =ministryName;
            this.programName = programName;
            this.subprogramName = subprogramName;
            this.socName = socName;
            this.accountName = accountName;
            this.projectName = projectName;
        }

        public string ministryName { get; set; }
        public string programName { get; set; }
        public string subprogramName { get; set; }
        public string socName { get; set; }
        public string accountName { get; set; }
        public string projectName { get; set; }


    }


}
