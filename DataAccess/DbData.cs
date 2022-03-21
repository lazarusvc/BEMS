using DataAccessLibrary.Models;


namespace DataAccessLibrary
{
    public class DbData : IDbData
    {
        private readonly ISqlDataAccess _db;
        public DbData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ProcessingYearModel>> GetYears()
        {
            string sql = "select year,ready_for_data_entry,year_closed from dbo.Processing_Year ORder by year desc;";
            return _db.GetListData<ProcessingYearModel, dynamic>(sql, new { });
        }


        public Task<string> GetMinistryName(string ministry)
        {
            string sql = "select [DESCRIPTION] from vw_ss_ministry_name where [NAME]=@ministry;";
            return _db.GetSingleValueData<string, dynamic>(sql, new { ministry });

        }

        public Task<string> GetProgramName(string program)
        {
            string sql = "select [DESCRIPTION] from vw_ss_program_name where [NAME]=@program;";
            return _db.GetSingleValueData<string, dynamic>(sql, new { program });
        }

        public Task<string> GetSubProgramName(string subprog)
        {
            string sql = "select [DESCRIPTION] from vw_ss_subprog_name where [NAME]=@subprog;";
            return _db.GetSingleValueData<string, dynamic>(sql, new { subprog });
        }

        public Task<string> GetAccountName(string account)
        {
            string sql = "select [DESCRIPTION] from vw_ss_account_name where [NAME]=@account;";
            return _db.GetSingleValueData<string, dynamic>(sql, new { account });
        }

        public Task<List<ListItemModel>> GetUserRoles()
        {

            string sql = @"SELECT [id] as Name , [roleDescp] as Description 
                            FROM [User_Roles]
                            ORDER BY roleDescp;";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { });
        }

        public Task<int> AddNewUser(UserModel um)
        {

            string sql = @"INSERT INTO Users(userName,userRole)
                        VALUES(@userName,@userRole)";

            return _db.ExecuteSql<UserModel>(sql, um);
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = @"select userName,userRole, roleDescp
                From dbo.Users
                LEFT JOIN User_Roles on id=userRole
                Order by userName;";
            return _db.GetListData<UserModel, dynamic>(sql, new { });
        }

        public Task<int> DeleteUser(string id)
        {

            string sql = @"DELETE FROM users
                           WHERE userName=@id;";

            return _db.ExecuteSql(sql, new { id });
        }

        public Task<int> UpdateUser(UserModel um)
        {

            string sql = @"Update users
                           userRole=@userRole 
                           WHERE userName=@userName;";

            return _db.ExecuteSql(sql, new { um });
        }

    }
}
