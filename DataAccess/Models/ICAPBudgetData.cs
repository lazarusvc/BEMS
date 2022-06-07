using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICAPBudgetData
    {
        Task<List<CAPBudgetModel>> GetData(int year);
        Task<List<CAPBudgetModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string username);
        Task<List<ListItemModel>> GetDependantAccounts(string ministry, string program, string subprogram, string username);
        Task<List<ListItemModel>> GetDependantMinistries(string username);
        Task<List<ListItemModel>> GetDependantPrograms(string ministry, string username);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string username);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string program, string username);
        Task<int> INSERT_CaptialEntry(CAPBudgetModel model);
    }
}