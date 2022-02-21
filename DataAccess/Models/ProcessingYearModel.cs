using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ProcessingYearModel
    {

        public ProcessingYearModel(int year, bool ready_for_data_entry)
          {
              this.year = year;
              this.ready_for_data_entry = ready_for_data_entry;
          }

          public int year { get; set; }
          public bool ready_for_data_entry { get; set; }

        
    }
}
