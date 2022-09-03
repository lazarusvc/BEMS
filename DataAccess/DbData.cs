using Dapper;
using DataAccessLibrary.Models;
using System.Data;

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
            string sql = "select year,ready_for_data_entry,year_closed from dbo.Processing_Year Order by year desc;";
            return _db.GetListData<ProcessingYearModel, dynamic>(sql, new { });
        }

        public Task<ProcessingYearModel> GetCurrentProcessingYear()
        {
            string sql = "select year,ready_for_data_entry,year_closed " +
                "from dbo.Processing_Year  WHERE ready_for_data_entry=1 " +
                "Order by year desc;";
            return _db.GetSingleRowData<ProcessingYearModel, dynamic>(sql, new { });
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

            string sql = @"UPDATE users
                           SET userRole=@userRole
                           WHERE userName=@userName;";

            return _db.ExecuteSql(sql,  um);
        }

        public Task<List<ListItemModel>> GetUserAccess(string username)
        {

            string sql = @"SELECT [subprogram] as Name , [DESCRIPTION] as Description 
                            FROM [User_Access]
                            LEFT JOIN vw_ss_subprog_name on [NAME]=[subprogram]
                            WHERE userName=@username
                            ORDER BY subprogram;";

            return _db.GetListData<ListItemModel, dynamic>(sql, new { username });
        }

        public Task<int> MergeUserAccess(List<UserAccessModel> uam)
        {

            string sql = @"MERGE User_Access AS Target
                            USING @TVP_Access	AS Source
                            ON Source.userName = Target.userName
                            AND Source.subprogram =Target.subprogram

                            WHEN NOT MATCHED BY Target THEN
                                INSERT (userName,subprogram) 
                                VALUES (Source.userName,Source.subprogram)   
    
                            WHEN NOT MATCHED BY Source
                            AND Target.userName IN (SELECT userName FROM @TVP_Access)  THEN
                                DELETE;";

            var dt = new DataTable();
            dt.Columns.Add("userName", typeof(string));
            dt.Columns.Add("subprogram", typeof(string));
            foreach (var item in uam)
            {
                dt.Rows.Add(item.userName,item.subprogram);
            }

            return _db.ExecuteSql(sql, new { TVP_Access = dt.AsTableValuedParameter("User_Access") });
        }

        public Task<string> GetUserRole(string user)
        {

            string sql = @"SELECT [userRole] 
                            FROM [Users]
                            WHERE userName=@user;";

            return _db.GetSingleValueData<string, dynamic>(sql, new { user });
        }


        public Task<List<ListItemModel2>> GetUserMinPrograms(string username)
        {

            string sql = @"SELECT Distinct ministry as Id,
                               [program] as Name
                               ,p.[DESCRIPTION] as Description
                              FROM [BEMS].[dbo].[vw_user_access]
                              LEFT JOIN vw_ss_program_name p on p.[NAME]=[program]
                            WHERE userName=@username
                            group by ministry,program,p.DESCRIPTION";

            return _db.GetListData<ListItemModel2, dynamic>(sql, new { username });
        }

        public Task<List<ListItemModel2>> GetSubmittedPrograms(int year)
        {

            string sql = @"SELECT Distinct ministry as Id,
                               [program] as Name
                               ,p.[DESCRIPTION] as Description
                            FROM [BEMS].[dbo].[vw_subprogram_submitted]
                            LEFT JOIN vw_ss_program_name p on p.[NAME]=[program]
                            WHERE [processing_year]=@year
                            group by ministry,program,p.DESCRIPTION
                            Order by ministry,program";

            return _db.GetListData<ListItemModel2, dynamic>(sql, new { year });
        }

        public Task<List<ListItemModel2>> GetUnSubmittedPrograms(int year)
        {

            string sql = @"SELECT Distinct ministry as Id,
                               [program] as Name
                               ,p.[DESCRIPTION] as Description
                            FROM [BEMS].[dbo].[vw_subprogram_unsubmitted]
                            LEFT JOIN vw_ss_program_name p on p.[NAME]=[program]
                            WHERE [processing_year]=@year
                            group by ministry,program,p.DESCRIPTION
                            Order by ministry,program";

            return _db.GetListData<ListItemModel2, dynamic>(sql, new { year });
        }


        public Task<List<StructureChangeModel>> GetAllStructureChanges()
        {

            string sql = @"SELECT *
                            FROM dbo.Structure_Change 
                            Order by proc_year desc,ministry,program,subprogram,account;                                                   
                           ";

            return _db.GetListData<StructureChangeModel, dynamic>(sql, new { });
        }

        public Task<StructureChangeModel> GetStructureChange(int id)
        {

            string sql = @"SELECT *
                            FROM dbo.Structure_Change  
                            WHERE id=@id;
                           ";

            return _db.GetSingleRowData<StructureChangeModel, dynamic>(sql, new { id });
        }
        public Task<int> AddStructureChange(StructureChangeModel structureChange)
        {

            string sql = @"INSERT INTO Structure_Change([proc_year],
	                                                    [ministry],
	                                                    [program],
	                                                    [subprogram],
	                                                    [soc],
	                                                    [account],
	                                                    [to_ministry],
	                                                    [to_program],
	                                                    [to_subprogram],
	                                                    [to_soc],
	                                                    [to_account],
	                                                    [descp])
                        VALUES(@proc_year,
	                            @ministry,
	                            @program,
	                            @subprogram,
	                            @soc,
	                            @account,
	                            @to_ministry,
	                            @to_program,
	                            @to_subprogram,
	                            @to_soc,
	                           @to_account,
	                            @descp);";

            return _db.ExecuteSql<StructureChangeModel>(sql, structureChange);
        }

        public Task<int> RemoveStructureChange(int id)
        {

            string sql = @"DELETE FROM Structure_Change
                           WHERE id=@id;";

            return _db.ExecuteSql(sql, new { id });
        }
        public Task<int> UpdateStructureChange(StructureChangeModel structureChange)
        {
            string sql = @"UPDATE Structure_Change
                        SET proc_year=@proc_year,
	                        ministry= @ministry,
	                        program= @program,
	                        subprogram=@subprogram,
	                        soc= @soc,
	                        account=@account,
	                        to_ministry= @to_ministry,
	                        to_program= @to_program,
	                        to_subprogram= @to_subprogram,
	                        to_soc= @to_soc,
	                        to_account= @to_account,
	                        descp=  @descp
                       WHERE id=@id";

            return _db.ExecuteSql<StructureChangeModel>(sql, structureChange);
        }

        public Task<List<ReportConfigModel>> GetAllReportConfig()
        {
            string sql = @"SELECT *
                            FROM dbo.Report_Config
                            Order by reportDesc;                                                   
                           ";

            return _db.GetListData<ReportConfigModel, dynamic>(sql, new { });
        }

        public Task<ReportConfigModel> GetReportConfig(int id)
        {
            string sql = @"SELECT *
                            FROM dbo.Report_Config
                            WHERE id=@id;
                           ";

            return _db.GetSingleRowData<ReportConfigModel, dynamic>(sql, new { id });
        }

        public Task<int> AddReportConfig(ReportConfigModel reportConfig)
        {
            string sql = @"INSERT INTO Report_Config([reportId]
                                                      ,[reportDesc]
                                                      ,[parUser]
                                                      ,[parMinistry]
                                                      ,[parProgram]
                                                      ,[parSubprogram]
                                                      ,[parSOC]
                                                      ,[parAccount])
                            VALUES(@reportId
                                  ,@reportDesc
                                  ,@parUser
                                  ,@parMinistry
                                  ,@parProgram
                                  ,@parSubprogram
                                  ,@parSOC
                                  ,@parAccount);";

            return _db.ExecuteSql<ReportConfigModel>(sql, reportConfig);
        }

        public Task<int> RemoveReportConfig(int id)
        {
            string sql = @"DELETE FROM Report_Config
                           WHERE id=@id;";

            return _db.ExecuteSql(sql, new { id });
        }

        public Task<int> UpdateReportConfig(ReportConfigModel reportConfig)
        {
            string sql = @"UPDATE Report_Config
                            set [reportId]=@reportId
                            ,[reportDesc]=@reportDesc
                            ,[parUser]=@parUser
                            ,[parMinistry]=@parMinistry
                            ,[parProgram]=@parProgram
                            ,[parSubprogram]=@parSubprogram
                            ,[parSOC]=@parSOC
                            ,[parAccount]=@parAccount
                        WHERE id=@id;  ;";

            return _db.ExecuteSql<ReportConfigModel>(sql, reportConfig);
        }
    }
}
