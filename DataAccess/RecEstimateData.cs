﻿using DataAccessLibrary.Models;


namespace DataAccessLibrary
{
    public class RecEstimateData : IRecEstimateData
    {
        private readonly ISqlDataAccess _db;

        public RecEstimateData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<BudgetEstimateEntryModel>> GetDataForYear(int year)
        {
            //todo:link the names to the query

            string sql = @"SELECT be.*, 
                            LEFT([account],3) as soc,
                            mn.[DESCRIPTION] as itemName, 
                            pn.[DESCRIPTION] as programName, 
                            spn.[DESCRIPTION] as subprogramName, 
                            socn.[DESCRIPTION] as socName, 
                            an.[DESCRIPTION] as accountName, 
                            pjn.[DESCRIPTION] as projectName, 
                            secn.[DESCRIPTION] as sectorName
                            FROM dbo.Budget_Estimates be
                            LEFT JOIN [dbo].[vw_ss_ministry_name] mn on be.item=mn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_program_name] pn on be.program=pn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_subprog_name] spn on be.subprog=spn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_account_name] socn on LEFT(be.[account],3)=socn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_account_name] an on be.account=an.[NAME]
                            LEFT JOIN [dbo].[vw_ss_project_name] pjn on be.project=pjn.[NAME]
                            LEFT JOIN [dbo].[vw_ss_sector_name] secn on be.sector=secn.[NAME]
                            WHERE  processing_year=@year";

            return _db.GetListData<BudgetEstimateEntryModel, dynamic>(sql, new { year });
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

        public Task<List<GroupingModel>> GetAccountDataForYear(int year, string ministry, string program, string subprogram)
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

            return _db.GetListData<GroupingModel, dynamic>(sql, new { year, ministry, program,subprogram });
        }

    }
}