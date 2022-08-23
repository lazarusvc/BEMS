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
                            Order by expiryDate desc,subprogram;;                                                   
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

            string sql = @"SELECT *
                            FROM dbo.Notifications                         
                            WHERE (subprogram in (Select subprogram from vw_user_access where username=@username)
                                    or subprogram is null)
                            AND expiryDate >= GETDATE()
                            Order by expiryDate desc,subprogram;
                           ";

            return _db.GetListData<NotificationModel, dynamic>(sql, new { username });
        }

        public Task<int> AddNotification(NotificationModel notification)
        {

            string sql = @"INSERT INTO NOTIFICATIONS([subprogram]
                                                      ,[message]
                                                      ,[expiryDate]
                                                      ,[dateEntered]
                                                      ,[enteredby]
                                                      ,[featured]
                                                      ,[header])
                        VALUES(@subprogram
                            ,@message
                            ,@expiryDate
                            ,GETDATE()
                            ,@enteredby
                            ,@featured
                            ,@header);";

            return _db.ExecuteSql<NotificationModel>(sql, notification);
        }

        public Task<int> RemoveNotification(int id)
        {

            string sql = @"DELETE FROM NOTIFICATIONS
                           WHERE id=@id;";

            return _db.ExecuteSql(sql, new { id });
        }

        public Task<int> RemoveExpiredNotifications()
        {

            string sql = @"DELETE FROM NOTIFICATIONS
                           WHERE expiryDate<GETDATE();";

            return _db.ExecuteSql(sql, new { });
        }

        public Task<int> UpdateNotification(NotificationModel notification)
        {
            string sql = @"UPDATE Notifications
                        SET [subprogram]=@subprogram
                          ,[message]=@message
                          ,[expiryDate]=@expiryDate
                          ,[dateModified]=GETDATE()
                          ,[modifiedBy]=@modifiedBy
                          ,[featured]=@featured
                          ,[header] =@header
                       WHERE id=@id";

            return _db.ExecuteSql<NotificationModel>(sql, notification);
        }
        public int EmailUsersNotification(NotificationModel notification)
        {
            //TODO: Implement emailing
            return 0;
        }
    }

}