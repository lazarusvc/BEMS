using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{

    public class NotificationModel
    {
        public int id { get; set; }
        public string subprogram { get; set; }
        public string header { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public DateTime expiryDate { get; set; }
        [Required]
        public DateTime dateEntered { get; set; }
        [Required]
        public string enteredby { get; set; }
        [Required]
        public bool featured { get; set; }
        public DateTime dateModified { get; set; }
        public string modifiedBy { get; set; }
    }
}
