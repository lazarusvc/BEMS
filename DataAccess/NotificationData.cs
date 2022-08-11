using DataAccessLibrary.Models;


namespace DataAccessLibrary
{
    public class NotificationData : INotificationData
    {
        private readonly ISqlDataAccess _db;

        public NotificationData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<NotificationModel>> GetAllNotifications()
        {

            string sql = @"SELECT *
                            FROM dbo.Notifications                                                     
                           ";

            return _db.GetListData<NotificationModel, dynamic>(sql, new { });
        }

        public Task<NotificationModel> GetNotification(int id)
        {

            string sql = @"SELECT *
                            FROM dbo.Notifications  
                            WHERe id=@id
                           ";

            return _db.GetSingleRowData<NotificationModel, dynamic>(sql, new { id });
        }


        public Task<List<ListItemModel>> GetNotifications(string subprogram)
        {
            //todo:link the names to the query

            string sql = @"SELECT featured,message
                            FROM dbo.Notifications                         
                            WHERE (subprogram=@subprogram
                                    or subprogram is null)
                            AND expiryDate >= GETDATE()
                           ";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { subprogram });
        }

        public Task<int> AddNewNotification(NotificationModel notification)
        {

            string sql = @"INSERT INTO NOTIFICATIONS()
                        VALUES()";

            return _db.ExecuteSql<NotificationModel>(sql, notification);
        }

        public Task<int> RemoveNotification(int id)
        {

            string sql = @"DELETE FROM NOTIFICATIONS
                           WHERE id=@id;";

            return _db.ExecuteSql(sql, new { id });
        }


        public Task<int> UpdateNotification(NotificationModel notification)
        {

            string sql = @"UPDATE Notification
                        SET 
                      
                         WHERE id=@id";

            return _db.ExecuteSql<NotificationModel>(sql, notification);
        }



    }
}