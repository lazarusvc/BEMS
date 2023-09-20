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

        public Task<List<BudgetEstimatesModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string account, string username)
        {
            //todo:link the names to the query

            string sql = @"SELECT *
                            FROM dbo.Budget_Estimates be                            
                            WHERE  processing_year=@year
                            AND ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            AND be.account=@account
                            AND (subprog in (select subprog from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                        
                           ";

            return _db.GetListData<BudgetEstimatesModel, dynamic>(sql, new { year, ministry, program, subprogram, account, username });
        }

        public Task<List<GroupingModel>> GetMinDataForYear(int year, string username)
        {
            if (username is null) { username="!"; }
            username=username.ToLower();
            string sql = @"SELECT be.ministry as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_ministry_name] mn on be.ministry=mn.[NAME]
                            WHERE  processing_year=@year
                            AND (ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            GROUP BY be.ministry, mn.[DESCRIPTION]
                            ORDER BY be.ministry";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, username });
        }

        public Task<List<GroupingModel>> GetProgramDataForYear(int year, string ministry, string username)
        {
            if (username is null) { username = "!"; }
            username = username.ToLower();
            string sql = @"SELECT be.program as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_program_name] mn on be.program=mn.[NAME]
                            WHERE  processing_year=@year
                            AND be.ministry=@ministry
                            AND (ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            GROUP BY be.program, mn.[DESCRIPTION]
                            ORDER BY be.program";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, username });
        }

        public Task<List<GroupingModel>> GetSubProgramDataForYear(int year, string ministry, string program, string username)
        {
            if (username is null)
            {
                username = "!";
            }
            username = username.ToLower();
            string sql = @"SELECT be.subprog as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName, max([vw_subprogram_sub_apv].status) as status
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_subprog_name] mn on be.subprog=mn.[NAME]
                        	LEFT OUTER JOIN [vw_subprogram_sub_apv] on  [vw_subprogram_sub_apv].processing_year=@year
                            AND [vw_subprogram_sub_apv].ministry=@ministry
                            AND [vw_subprogram_sub_apv].program=@program
                            AND [vw_subprogram_sub_apv].subprog=be.subprog
                            WHERE  be.processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND (be.program in (select program from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            GROUP BY be.subprog, mn.[DESCRIPTION]
                            ORDER BY be.subprog";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program, username });
        }

        public Task<List<GroupingModel>> GetAccountTypeDataForYear(int year, string ministry, string program, string subprogram, string username)
        {if (username is null)
            {
                username = "!";
            }
            username = username.ToLower();
            string sql = @"SELECT SUBSTRING(be.account,1,3) as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName,  count(o.cc) as flagged
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_account_name] mn on SUBSTRING(be.account,1,3) =mn.[NAME]							
                            LEFT OUTER JOIN (SELECT SUBSTRING(account,1,3) as acc,count(*) as cc
                                                          FROM dbo.Budget_Estimates
                                                          WHERE  processing_year=@year
														  AND ministry=@ministry
														  AND program=@program
														  AND subprog=@subprogram
							                              AND flagged=1
														  group by SUBSTRING(account,1,3)) as o on SUBSTRING(be.account,1,3) = o.acc
							WHERE  be.processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            AND (be.subprog in (select subprog from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            GROUP BY SUBSTRING(be.account,1,3) , mn.[DESCRIPTION]
                            ORDER BY SUBSTRING(be.account,1,3) ";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program, subprogram, username });
        }

        public Task<List<GroupingModel>> GetAccountDataForYear(int year, string ministry, string program, string subprogram, string accountType, string username)
        {if (username is null)
            {
                username = "!";
            }
            username = username.ToLower();
            string sql = @"SELECT be.account as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName,  count(o.cc) as flagged
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_account_name] mn on SUBSTRING(be.account,1,3) =mn.[NAME]							
                            LEFT OUTER JOIN (SELECT account,count(*) as cc
                                                          FROM dbo.Budget_Estimates
                                                          WHERE  processing_year=@year
														  AND ministry=@ministry
														  AND program=@program
														  AND subprog=@subprogram
							                              AND flagged=1
														  group by account) as o on be.account = o.account
						    WHERE  be.processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            AND be.account like @accountType+'%'
                            AND (be.subprog in (select subprog from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                            GROUP BY be.account , mn.[DESCRIPTION]
                            ORDER BY be.account;
                             ";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program, subprogram, accountType, username });
        }
        public Task<List<ListItemModel>> GetDependantMinistries(string username)
        {
            if (username is null) { username = "!"; }
            username = username.ToLower();
            string sql = @"SELECT distinct Name , Description 
                            FROM [dbo].[vw_ss_ministry_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.ministry
                            WHERE (b.ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { username});
        }
        public Task<List<ListItemModel>> GetDependantPrograms(string ministry, string username)
        {
            if (username is null) { username = "!"; }
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
            if (username is null) { username = "!"; }
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
            if (username is null) { username = "!"; }
            username = username.ToLower();
            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_subprog_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.subprog
                            WHERE b.ministry=@ministry
                             AND (b.ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                           
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { ministry, username});
        }
        public Task<List<ListItemModel>> GetDependantAccountTypes()
        {            
            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_account_name] a                            
                            WHERE LEN(a.Name)=3
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { });
        }

        public Task<List<ListItemModel>> GetDependantAccounts(string acctype)
        {
            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_account_name] a
                            LEFT JOIN  vw_ss_ledger_accounts b ON a.Name=b.account
                            WHERE b.account like @acctype+'%'                            
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { acctype});
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
                            ,[is_adjustment]
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
                            ,@is_adjustment
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
                            ,is_adjustment=@is_adjustment
                         WHERE id=@id";

            return _db.ExecuteSql<BudgetEstimatesModel>(sql, bem);
        }

        public Task<int> SetRecEntryStatus(int pyear,string subprog, int status)
        {

            string sql = @"UPDATE BUDGET_ESTIMATES
                        SET 
                           [entry_status_id]=@status
                         WHERE subprog=@subprog
                        AND processing_year=@pyear";

            return _db.ExecuteSql<dynamic>(sql, new { pyear,subprog, status });
        }

        public Task<int> GetSubProgramStatus(int pyear, string subprog)
        {

            string sql = @"SELECT [status] 
                            FROM [vw_subprogram_sub_apv]
                            WHERE processing_year=@pyear
                            AND subprog=@subprog";

            return _db.GetSingleValueData<int, dynamic>(sql, new { pyear, subprog });
        }

        public Task<List<ListItemModel>> GetAllSubPrograms()
        {

            string sql = @"SELECT distinct Name, Description 
                            FROM [dbo].[vw_ss_subprog_name] a
                            INNER JOIN  vw_ss_ledger_accounts b ON a.Name=b.subprog
                            ORDER BY Name";

            return _db.GetListData<ListItemModel, dynamic>(sql,new { });
        }
        public Task<List<GroupingModel>> GetSOCDataForYear(int year, string username)
        {
            username = username.ToLower();
            string sql = @"SELECT SUBSTRING(be.account,1,3) as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_account_name] mn on SUBSTRING(be.account,1,3)=mn.[NAME]
                            WHERE  processing_year=@year
                            AND (ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            GROUP BY SUBSTRING(be.account,1,3), mn.[DESCRIPTION]
                            ORDER BY SUBSTRING(be.account,1,3)";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, username });
        }

        public Task<List<GroupingModel>> GetSOCMinDataForYear(int year, string soc, string username)
        {if (username is null)
            {
                username = "!";
            }
            username = username.ToLower();
            string sql = @"SELECT be.ministry as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_ministry_name] mn on be.ministry=mn.[NAME]
                            WHERE  processing_year=@year
                            AND (ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            AND SUBSTRING(be.account,1,3)=@soc
                            GROUP BY be.ministry, mn.[DESCRIPTION]
                            ORDER BY be.ministry";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, soc, username });
        }

        public Task<List<GroupingModel>> GetSOCProgramDataForYear(int year, string soc,string ministry, string username)
        {if (username is null)
            {
                username = "!";
            }
            username = username.ToLower();
            string sql = @"SELECT be.program as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_program_name] mn on be.program=mn.[NAME]
                            WHERE  processing_year=@year
                            AND be.ministry=@ministry
                            AND (ministry in (select ministry from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            AND SUBSTRING(be.account,1,3)=@soc
                            GROUP BY be.program, mn.[DESCRIPTION]
                            ORDER BY be.program";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, soc, ministry, username });
        }

        public Task<List<GroupingModel>> GetSOCSubProgramDataForYear(int year, string soc, string ministry, string program, string username)
        {
            if (username is null) { username = "!"; }
            username = username.ToLower();
            string sql = @"SELECT be.subprog as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName, max([vw_subprogram_sub_apv].status) as status
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_subprog_name] mn on be.subprog=mn.[NAME]
                        	LEFT OUTER JOIN [vw_subprogram_sub_apv] on  [vw_subprogram_sub_apv].processing_year=@year
                            AND [vw_subprogram_sub_apv].ministry=@ministry
                            AND [vw_subprogram_sub_apv].program=@program
                            AND [vw_subprogram_sub_apv].subprog=be.subprog
                            WHERE  be.processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND (be.program in (select program from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))
                            AND SUBSTRING(be.account,1,3)=@soc
                            GROUP BY be.subprog, mn.[DESCRIPTION]
                            ORDER BY be.subprog";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, soc, ministry, program, username });
        }


        public Task<List<GroupingModel>> GetSOCAccountDataForYear(int year, string ministry, string program, string subprogram, string accountType, string username)
        {
            if (username is null) { username = "!"; }
            username = username.ToLower();
            string sql = @"SELECT be.account as item, sum(year0_amount) as year0, sum(year1_amount) as year1, sum(year2_amount) as year2, sum(year3_amount) as year3 ,
                            mn.[DESCRIPTION] as itemName,  count(o.cc) as flagged
							FROM dbo.Budget_Estimates be
                            LEFT OUTER JOIN [dbo].[vw_ss_account_name] mn on be.account =mn.[NAME]							
                            LEFT OUTER JOIN (SELECT account,count(*) as cc
                                                          FROM dbo.Budget_Estimates
                                                          WHERE  processing_year=@year
														  AND ministry=@ministry
														  AND program=@program
														  AND subprog=@subprogram
							                              AND flagged=1
														  group by account) as o on be.account = o.account
						    WHERE  be.processing_year=@year
                            AND be.ministry=@ministry
                            AND be.program=@program
                            AND be.subprog=@subprogram
                            AND be.account like @accountType+'%'
                            AND (be.subprog in (select subprog from vw_user_access ua where LOWER(userName)=@username)
                                OR 'Administrator' in (select userRole from Users ua where LOWER(userName)=@username))                          
                            GROUP BY be.account , mn.[DESCRIPTION]
                            ORDER BY be.account;
                             ";

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program, subprogram, accountType, username });
        }

    }
       
}
