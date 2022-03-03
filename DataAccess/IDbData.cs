using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IDbData
    {
        Task<string> GetMinistryName(string ministry);
        Task<string> GetProgramName(string program);
        Task<string> GetSubProgramName(string program);
        Task<RoleModel> GetRole(string name);
        Task<List<RoleModel>> GetRoles();
        Task<List<RoleModel>> GetUserRoles(string username);
        Task<List<ProcessingYearModel>> GetYears();
    }
}