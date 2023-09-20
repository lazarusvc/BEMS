using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class StructureChangeModel
    {
        public int id { get; set; }
        [Required]
        public int proc_year { get; set; }
        [Required]
        public string ministry { get; set; }
        [Required]
        public string program { get; set; }
        [Required]
        public string subprogram { get; set; }
        public string soc { get; set; }
        public string account { get; set; }
        [Required]
        public string to_ministry { get; set; }
        [Required]
        public string to_program { get; set; }
        [Required]
        public string to_subprogram { get; set; }
        public string to_soc { get; set; }
        public string to_account { get; set; }
        public string descp { get; set; }
    }
}
