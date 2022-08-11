using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface INotificationData
    {
        Task<int> AddNewNotification(NotificationModel notification);
        Task<List<ListItemModel>> GetNotifications(string subprogram);
        Task<List<NotificationModel>> GetAllNotifications();
        Task<NotificationModel> GetNotification(int id);
        Task<int> RemoveNotification(int id);
        Task<int> UpdateNotification(NotificationModel notification);
    }
}