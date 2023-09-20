using Budget_Estimates_Management_System.Models;

namespace Budget_Estimates_Management_System.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
