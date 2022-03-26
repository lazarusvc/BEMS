using DataAccessLibrary.Models;


namespace DataAccessLibrary
{
    public class RecEstimateData : IRecEstimateData
    {
        private readonly ISqlDataAccess _db;

        public RecEstimateData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<BudgetEstimatesModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string account)
        {
            //todo:link the names to the query

            string sql = @"SELECT *
                            FROM dbo.Budget_Estimates be                            
                            WHERE  processing_year=@year
                            AND ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            AND be.account=@account
                           ";

            return _db.GetListData<BudgetEstimatesModel, dynamic>(sql, new { year, ministry, program, subprogram, account });
        }

        public Task<List<GroupingModel>> GetMinDataForYear(int year)
        {

            string sql = @"SELECT be.ministry as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_ministry_name] mn on be.ministry=mn.[NAME]
                            WHERE  processing_year=@year
                            GROUP BY be.ministry, mn.[DESCRIPTION]
                            ORDER BY be.ministry";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year });
        }

        public Task<List<GroupingModel>> GetProgramDataForYear(int year, string ministry)
        {

            string sql = @"SELECT be.program as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_program_name] mn on be.program=mn.[NAME]
                            WHERE  processing_year=@year
                            AND be.ministry=@ministry
                            GROUP BY be.program, mn.[DESCRIPTION]
                            ORDER BY be.program";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry });
        }

        public Task<List<GroupingModel>> GetSubProgramDataForYear(int year, string ministry, string program)
        {

            string sql = @"SELECT be.subprog as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_subprog_name] mn on be.subprog=mn.[NAME]
                            WHERE  processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            GROUP BY be.subprog, mn.[DESCRIPTION]
                            ORDER BY be.subprog";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program });
        }

        public Task<List<GroupingModel>> GetAccountTypeDataForYear(int year, string ministry, string program, string subprogram)
        {

            string sql = @"SELECT SUBSTRING(be.account,1,3) as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_account_name] mn on SUBSTRING(be.account,1,3) =mn.[NAME]
                            WHERE  processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            GROUP BY SUBSTRING(be.account,1,3) , mn.[DESCRIPTION]
                            ORDER BY SUBSTRING(be.account,1,3) ";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program, subprogram });
        }

        public Task<List<GroupingModel>> GetAccountDataForYear(int year, string ministry, string program, string subprogram, string accountType)
        {

            string sql = @"SELECT be.account as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_account_name] mn on be.account =mn.[NAME]
                            WHERE  processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            AND be.account like @accountType+'%'
                            GROUP BY be.account, mn.[DESCRIPTION]
                            ORDER BY be.account ";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program, subprogram, accountType });
        }

        public Task<List<ListItemModel>> GetDependantMinistries()
        {

            string sql = @"SELECT distinct Name , Description 
                            FROM [dbo].[vw_ss_ministry_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.ministry
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { });
        }
        public Task<List<ListItemModel>> GetDependantPrograms(string ministry)
        {

            string sql = @" SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_program_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.program
                            WHERE b.ministry=@ministry
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry });
        }
        public Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string program)
        {

            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_subprog_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.subprog
                            WHERE b.ministry=@ministry
                            and b.program=@program
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, program });
        }

        public Task<List<ListItemModel>> GetDependantSubPrograms(string ministry)
        {

            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_subprog_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.subprog
                            WHERE b.ministry=@ministry
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry});
        }
        public Task<List<ListItemModel>> GetDependantAccountTypes(string ministry, string program, string subprogram)
        {

            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_account_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=LEFT(b.account,3)
                            WHERE b.ministry=@ministry
                            and b.program=@program
                            and b.subprog=@subprogram
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, program, subprogram });
        }

        public Task<List<ListItemModel>> GetDependantAccounts(string ministry, string program, string subprogram, string acctype)
        {

            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_account_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.account
                            WHERE b.ministry=@ministry
                            and b.program=@program
                            and b.subprog=@subprogram
                            and b.account like @acctype+'%'
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, program, subprogram, acctype });
        }
        public Task<List<ListItemModel>> GetEnteredAccounts(int year, string ministry, string program, string subprogram, string acctype)
        {

            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_account_name] a
                            LEFT JOIN  Budget_Estimates b ON a.Name=b.account
                            WHERE b.processing_year=@year
                            and b.ministry=@ministry
                            and b.program=@program
                            and b.subprog=@subprogram
                            and b.account like @acctype+'%'
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { year, ministry, program, subprogram, acctype });
        }

        public Task<int> AddNewRecEntry(BudgetEstimatesModel bem)
        {

            string sql = @"INSERT INTO BUDGET_ESTIMATES([processing_year]
                            ,[ministry]
                            ,[program]
                            ,[subprog]
                            ,[account]
                            ,[project]
                            ,[sof]
                            ,[sector]
                            ,[lastcode]
                            ,[quantity]
                            ,[year0_amount]
                            ,[year1_amount]
                            ,[year2_amount]
                            ,[year3_amount]
                            ,[is_by_law]
                            ,[comment]
                            ,[flagged]
                            ,[flagged_comment]
                            ,[modified_by]
                            ,[last_modified]
                            ,[entry_status_id]
                            ,[label])
                        VALUES(@processing_year
                            ,@ministry
                            ,@program
                            ,@subprog
                            ,@account
                            ,@project
                            ,@sof
                            ,@sector
                            ,@lastcode
                            ,@quantity
                            ,@year0_amount
                            ,@year1_amount
                            ,@year2_amount
                            ,@year3_amount
                            ,@is_by_law
                            ,@comment
                            ,@flagged
                            ,@flagged_comment
                            ,@modified_by
                            ,@last_modified
                            ,@entry_status_id
                            ,@label)";

            return _db.ExecuteSql<BudgetEstimatesModel>(sql, bem);
        }

        public Task<int> RemoveRecEntry(int id)
        {

            string sql = @"DELETE FROM BUDGET_ESTIMATES
                           WHERE id=@id;";

            return _db.ExecuteSql(sql, new { id });
        }


        public Task<int> UpdateRecEntry(BudgetEstimatesModel bem)
        {

            string sql = @"UPDATE BUDGET_ESTIMATES
                        SET 
                           quantity =@quantity
                            ,year0_amount=@year0_amount
                            ,year1_amount=@year1_amount
                            ,year2_amount=@year2_amount
                            ,year3_amount=@year3_amount
                            ,is_by_law=@is_by_law
                            ,comment=@comment
                            ,flagged=@flagged
                            ,flagged_comment=@flagged_comment
                            ,modified_by=@modified_by
                            ,last_modified=@last_modified
                            ,entry_status_id=@entry_status_id
                            ,label=@label
                         WHERE id=@id";

            return _db.ExecuteSql<BudgetEstimatesModel>(sql, bem);
        }

    }
}
