using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface INotificationData
    {
        Task<int> AddNotification(NotificationModel notification);
        Task<List<NotificationModel>> GetNotifications(string username);
        Task<List<NotificationModel>> GetAllNotifications();
        Task<NotificationModel> GetNotification(int id);
        Task<int> RemoveNotification(int id);
        Task<int> UpdateNotification(NotificationModel notification);
        Task<int> RemoveExpiredNotifications();
        Task<List<String>> GetUsersIn(string subprog);
    }
}