using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UserModel
    {
        [Required(AllowEmptyStrings = false)]
        public string userName { get; set; }
        [Required]
        public string userRole { get; set; }
        public string roleDescp { get; set; }
    }
}
