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

        public Task<List<RoleModel>> GetRoles()
        {
            string sql = "select name,description from dbo.role;";
            return _db.GetListData<RoleModel, dynamic>(sql, new { });
        }

        public Task<RoleModel> GetRole(string name)
        {
            string sql = "select name,description from dbo.role where name=@name;";
            return _db.GetData<RoleModel, dynamic>(sql, new { name });
        }

        public Task<List<RoleModel>> GetUserRoles(string username)
        {
            string sql = @"select name,description 
                            from dbo.user_role ur
                            inner join dbo.role r on  ur.role=r.name
                            where  ur.username=@username";
            return _db.GetListData<RoleModel, dynamic>(sql, new { username });
        }

        public Task<List<ProcessingYearModel>> GetYears()
        {
            string sql = "select year,ready_for_data_entry from dbo.Processing_Year;";
            return _db.GetListData<ProcessingYearModel, dynamic>(sql, new { });
        }


        public Task<string> GetMinistryName(string ministry)
        {
            string sql = "select [DESCRIPTION] from vw_ss_ministry_name where [NAME]=@ministry;";
            return _db.GetSingleData<string, dynamic>(sql, new { ministry });
        }

        public Task<string> GetProgramName(string program)
        {
            string sql = "select [DESCRIPTION] from vw_ss_program_name where [NAME]=@program;";
            return _db.GetSingleData<string, dynamic>(sql, new { program });
        }

        public Task<string> GetSubprogramName(string subprog)
        {
            string sql = "select [DESCRIPTION] from vw_ss_subprog_name where [NAME]=@subprog;";
            return _db.GetSingleData<string, dynamic>(sql, new { subprog });
        }

    }
}
