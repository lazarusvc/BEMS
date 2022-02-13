using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _db.LoadDataList<RoleModel, dynamic>(sql, new { });
        }

        public Task<RoleModel> GetRole(string name)
        {
            string sql = "select name,description from dbo.role where name=@name;";
            return _db.LoadData<RoleModel, dynamic>(sql, new { name });
        }

        public Task<List<RoleModel>> GetUserRoles(string username)
        {
            string sql = @"select name,description 
                            from dbo.user_role ur
                            inner join dbo.role r on  ur.role=r.name
                            where  ur.username=@username";
            return _db.LoadDataList<RoleModel, dynamic>(sql, new { username });
        }

    }
}
