using System.ComponentModel.DataAnnotations;

namespace Budget_Estimates_Management_System.Models
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
