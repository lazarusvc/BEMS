using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IDbData
    {
        Task<List<MinistryGroupModel>> GetMinDataForYear(int year);
        Task<List<BudgetEstimateEntryModel>> GetDataForYear(int year);
        Task<RoleModel> GetRole(string name);
        Task<List<RoleModel>> GetRoles();
        Task<List<RoleModel>> GetUserRoles(string username);
        Task<List<ProcessingYearModel>> GetYears();
    }
}