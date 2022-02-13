using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Roles
    {

        public Roles (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

       // public ICollection<UserRole> UserRoles { get; set; }
    }
}
