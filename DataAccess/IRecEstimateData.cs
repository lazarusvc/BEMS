using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRecEstimateData
    {
        Task<List<GroupingModel>> GetMinDataForYear(int year);
        Task<List<GroupingModel>> GetProgramDataForYear(int year, string ministry);
        Task<List<GroupingModel>> GetSubProgramDataForYear(int year, string ministry, string program);
        Task<List<GroupingModel>> GetAccountDataForYear(int year, string ministry, string program, string subprogram);
        Task<List<BudgetEstimateEntryModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string account);
        Task<List<ListItemModel>> GetDependantMinistries();
        Task<List<ListItemModel>> GetDependantPrograms(string ministry);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string program);
        Task<List<ListItemModel>> GetDependantAccountTypes(string ministry, string program, string subprogram);
        Task<List<ListItemModel>> GetDependantAccounts(string ministry, string program, string subprogram,string acctype);
        Task<List<ListItemModel>> GetEnteredAccounts(int year, string ministry, string program, string subprogram, string acctype);
        Task<int> SaveRecEntry(BudgetEstimatesModel bem);
    }
}