using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class BudgetEstimateEntryModel : BudgetEstimatesModel
    {
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
