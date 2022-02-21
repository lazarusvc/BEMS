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

        public Task<List<BudgetEstimateEntryModel>> GetDataForYear(int year)
        {
            //todo:link the names to the query

            string sql = @"SELECT be.*, 
                            LEFT([account],3) as soc,
                            mn.[DESCRIPTION] as ministryName, 
                            pn.[DESCRIPTION] as programName, 
                            spn.[DESCRIPTION] as subprogramName, 
                            socn.[DESCRIPTION] as socName, 
                            an.[DESCRIPTION] as accountName, 
                            pjn.[DESCRIPTION] as projectName, 
                            secn.[DESCRIPTION] as sectorName
                            FROM dbo.Budget_Estimates be
                            LEFT JOIN [dbo].[vw_ss_ministry_name] mn on be.ministry=mn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_program_name] pn on be.program=pn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_subprog_name] spn on be.subprog=spn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_account_name] socn on LEFT(be.[account],3)=socn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_account_name] an on be.account=an.[NAME]
                            LEFT JOIN [dbo].[vw_ss_project_name] pjn on be.project=pjn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_sector_name] secn on be.sector=secn.[NAME]
                            WHERE  processing_year=@year";

            return _db.GetListData<BudgetEstimateEntryModel, dynamic>(sql, new { year });
        }

        public Task<List<ProcessingYearModel>> GetYears()
        {
            string sql = "select year,ready_for_data_entry from dbo.Processing_Year;";
            return _db.GetListData<ProcessingYearModel, dynamic>(sql, new { });
        }

    }
}
