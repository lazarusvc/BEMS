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
                            FROM dbo.Notifications  ;                                                   
                           ";

            return _db.GetListData<NotificationModel, dynamic>(sql, new { });
        }

        public Task<NotificationModel> GetNotification(int id)
        {

            string sql = @"SELECT *
                            FROM dbo.Notifications  
                            WHERe id=@id;
                           ";

            return _db.GetSingleRowData<NotificationModel, dynamic>(sql, new { id });
        }


        public Task<List<NotificationModel>> GetNotifications(string username)
        {
            //todo:link the names to the query

            string sql = @"SELECT featured,message
                            FROM dbo.Notifications                         
                            WHERE (subprogram in (Select subprogram from vw_user_access where username=@username)
                                    or subprogram is null)
                            AND expiryDate >= GETDATE();
                           ";

            return _db.GetListData<NotificationModel, dynamic>(sql, new { username });
        }

        public Task<int> AddNewNotification(NotificationModel notification)
        {

            string sql = @"INSERT INTO NOTIFICATIONS([subprogram]
                                                      ,[message]
                                                      ,[expiryDate]
                                                      ,[dateEntered]
                                                      ,[enteredby]
                                                      ,[featured])
                        VALUES(@subprogram
                            ,@message
                            ,@expiryDate
                            ,@dateEntered
                            ,@enteredby
                            ,@featured);";

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