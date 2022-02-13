using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UserRole
    {
        public UserRole(string username)
        {
            this.UserName = username;
        //    this.Role = role;
        }

        public string UserName { get; set; }
        //public string Role { get; set; }
        
        public Roles Roles { get; set; }
    }
}
