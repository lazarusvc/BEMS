namespace DataAccessLibrary.Models
{
    public class RoleModel
    {

        public RoleModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        // public ICollection<UserRole> UserRoles { get; set; }
    }
}
