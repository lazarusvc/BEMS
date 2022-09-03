using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IDbData
    {
        Task<string> GetMinistryName(string ministry);
        Task<string> GetProgramName(string program);
        Task<string> GetSubProgramName(string program);
        Task<string> GetAccountName(string account);
        Task<List<ProcessingYearModel>> GetYears();
        Task<ProcessingYearModel> GetCurrentProcessingYear();
        Task<List<ListItemModel>> GetUserRoles();
        Task<int> AddNewUser(UserModel um);
        Task<List<UserModel>> GetUsers();
        Task<int> DeleteUser(string id);
        Task<int> UpdateUser(UserModel um);
        Task<List<ListItemModel>> GetUserAccess(string username);
        Task<int> MergeUserAccess(List<UserAccessModel> uam);
        Task<string> GetUserRole(string user);
        Task<List<ListItemModel2>> GetUserMinPrograms(string username);
        Task<List<ListItemModel2>> GetSubmittedPrograms(int year);
        Task<List<ListItemModel2>> GetUnSubmittedPrograms(int year);
        Task<List<StructureChangeModel>> GetAllStructureChanges();
        Task<StructureChangeModel> GetStructureChange(int id);
        Task<int> AddStructureChange(StructureChangeModel structureChange);
        Task<int> RemoveStructureChange(int id);
        Task<int> UpdateStructureChange(StructureChangeModel structureChange);
        Task<List<ReportConfigModel>> GetAllReportConfig();
        Task<ReportConfigModel> GetReportConfig(int id);
        Task<int> AddReportConfig(ReportConfigModel reportConfig);
        Task<int> RemoveReportConfig(int id);
        Task<int> UpdateReportConfig(ReportConfigModel reportConfig);
    }
}