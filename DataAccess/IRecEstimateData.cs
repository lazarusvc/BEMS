using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRecEstimateData
    {
        Task<List<GroupingModel>> GetMinDataForYear(int year, string username);
        Task<List<GroupingModel>> GetProgramDataForYear(int year, string ministry);
        Task<List<GroupingModel>> GetSubProgramDataForYear(int year, string ministry, string program);
        Task<List<GroupingModel>> GetAccountTypeDataForYear(int year, string ministry, string program, string subprogram);
        Task<List<GroupingModel>> GetAccountDataForYear(int year, string ministry, string program, string subprogram, string accountType);
        Task<List<BudgetEstimatesModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string account);
        Task<List<ListItemModel>> GetDependantMinistries();
        Task<List<ListItemModel>> GetDependantPrograms(string ministry);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string program);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry);
        Task<List<ListItemModel>> GetDependantAccountTypes(string ministry, string program, string subprogram);
        Task<List<ListItemModel>> GetDependantAccounts(string ministry, string program, string subprogram, string acctype);
        Task<List<ListItemModel>> GetEnteredAccounts(int year, string ministry, string program, string subprogram, string acctype);
        Task<int> AddNewRecEntry(BudgetEstimatesModel bem);
        Task<int> RemoveRecEntry(int id);
        Task<int> UpdateRecEntry(BudgetEstimatesModel bem);
        Task<int> SetRecEntryStatus(int pyear, string subprog, int status);
        Task<int> GetSubProgramStatus(int pyear, string subprog);
        Task<List<ListItemModel>> GetAllSubPrograms();
    }
}