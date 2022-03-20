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
        [Required]
        public string userName { get; set; }
        [Required]
        public Int16 userRole { get; set; }
    }
}
