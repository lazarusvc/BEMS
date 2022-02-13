using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UserRoleModel
    {
        public UserRoleModel(string username)
        {
            this.UserName = username;
        }

        public string UserName { get; set; }
        //public string Role { get; set; }
        
        //public RoleModel Roles { get; set; }
    }
}
