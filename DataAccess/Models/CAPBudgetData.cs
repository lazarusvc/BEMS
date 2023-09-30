using DataAccessLibrary.Models;
using System.Reflection;

namespace DataAccessLibrary
{
    public class CAPBudgetData : ICAPBudgetData
    {
        private readonly ISqlDataAccess _db;
        public CAPBudgetData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<CAPBudgetModel>> GetData(int year)
        {
            string sql =
                @"SELECT * 
                FROM [GOCDBudget_NW].[dbo].[Capital_Budget] cb                            
                WHERE  cb.processing_year=@year";
            return _db.GetListData<CAPBudgetModel, dynamic>(sql, new { year});
        }
        public Task<List<CAPBudgetModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string username)
        {
            string sql =
                @"SELECT * 
                FROM [GOCDBudget_NW].[dbo].[Capital_Budget] cb                            
                WHERE  cb.processing_year=@year
                AND cb.ministry=@ministry
                AND cb.program=@program
                AND cb.subprog=@subprogram
                AND (cb.subprog in (select subprog from vw_user_access ua where LOWER(userName)=@username)
                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                ";
            return _db.GetListData<CAPBudgetModel, dynamic>(sql, new { year, ministry, program, subprogram, username });
        }
        public Task<int> INSERT_CaptialEntry(CAPBudgetModel model)
        {
            string sql =
                @"INSERT INTO Capital_Budget
                           ([ldr_entity_id]
                           ,[ministry]
                           ,[program]
                           ,[subprog]
                           ,[account]
                           ,[project]
                           ,[sof]
                           ,[sector]
                           ,[lastcode]
                           ,[curr_code]
                           ,[Name]
                           ,[Name2]
                           ,[ldr_amt_0]
                           ,[ldr_amt_1]
                           ,[Expr1000]
                           ,[Expr1001]
                           ,[Expr1002]
                           ,[Expr1003]
                           ,[Expr1004]
                           ,[Expr1005]
                           ,[Expr1006]
                           ,[Expr1007]
                           ,[Expr1008]
                           ,[Expr1009]
                           ,[Expr1010]
                           ,[Expr1011]
                           ,[Expr1012]
                           ,[Expr1013]
                           ,[processing_year])
                     VALUES
                           ('D'
                           ,@ministry
                           ,@program
                           ,@subprog
                           ,@account
                           ,@project
                           ,@sof
                           ,@sector
                           ,@lastcode
                           ,@curr_code
                           ,@Name
                           ,@Name2
                           ,@ldr_amt_0
                           ,@ldr_amt_1
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,0
                           ,@processing_year)";
            return _db.ExecuteSql<CAPBudgetModel>(sql, model);
        }
        public Task<int> Update(CAPBudgetModel model)
        {
            string sql = @"
                UPDATE Capital_Budget
                SET
                    [ministry] = @ministry,
                    [program] = @program,
                    [subprog] = @subprog,
                    [account] = @account,
                    [project] = @project,
                    [sof] = @sof,
                    [sector] = @sector,
                    [lastcode] = @lastcode,
                    [curr_code] = @curr_code,
                    [Name] = @Name,
                    [Name2] = @Name2,
                    [ldr_amt_0] = @ldr_amt_0,
                    [ldr_amt_1] = @ldr_amt_1,
                    [processing_year] = @processing_year
                WHERE
                    [id] = @id;
            ";
            return _db.ExecuteSql<CAPBudgetModel>(sql, model);
        }
        public Task<List<ListItemModel>> GetDependantMinistries(string username)
        {
            username = username.ToLower();
            string sql = @"SELECT distinct Name , Description 
                            FROM [dbo].[vw_ss_ministry_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.ministry
                            WHERE (b.ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { username });
        }
        public Task<List<ListItemModel>> GetDependantPrograms(string ministry, string username)
        {
            username = username.ToLower();
            string sql = @" SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_program_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.program
                            WHERE b.ministry=@ministry
                             AND (b.ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                           ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, username });
        }
        public Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string program, string username)
        {
            username = username.ToLower();
            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_subprog_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.subprog
                            WHERE b.ministry=@ministry
                            and b.program=@program
                            AND (b.program in (select program from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                                                     
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, program, username });
        }
        public Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string username)
        {
            username = username.ToLower();
            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_subprog_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.subprog
                            WHERE b.ministry=@ministry
                             AND (b.ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, username });
        }
        public Task<List<ListItemModel>> GetDependantAccounts(string ministry, string program, string subprogram, string username)
        {
            username = username.ToLower();
            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_account_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.account
                            WHERE b.ministry=@ministry
                            and b.program=@program
                            and b.subprog=@subprogram
                            and b.account like @acctype+'%'
                            AND (b.subprog in (select subprog from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                           
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, program, subprogram, username });
        }

        public Task<int> Delete(int id)
        {
            string sql = @"DELETE FROM  Capital_Budget WHERE Id = @id";
            return _db.ExecuteSql<dynamic>(sql, new { id });
        }
    }
}
