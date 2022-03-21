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
        Task<List<ListItemModel>> GetUserRoles();
        Task<int> AddNewUser(UserModel um);
        Task<List<UserModel>> GetUsers();
        Task<int> DeleteUser(string id);
        Task<int> UpdateUser(UserModel um);
    }
}