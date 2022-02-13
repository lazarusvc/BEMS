using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IDbData
    {
        Task<RoleModel> GetRole(string name);
        Task<List<RoleModel>> GetRoles();
    }
}