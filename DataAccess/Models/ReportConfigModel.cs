using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ReportConfigModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string reportId { get; set; }
        [Required]
        public string reportDesc { get; set; }
        [Required]
        public bool parUser { get; set; }
        [Required]
        public bool parMinistry { get; set; }
        [Required]
        public bool parProgram { get; set; }
        [Required]
        public bool parSubprogram { get; set; }
        [Required]
        public bool parSOC { get; set; }
        [Required]
        public bool parAccount { get; set; }
    }
}
