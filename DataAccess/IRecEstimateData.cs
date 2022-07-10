using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRecEstimateData
    {
        Task<List<GroupingModel>> GetMinDataForYear(int year, string username);
        Task<List<GroupingModel>> GetProgramDataForYear(int year, string ministry, string username);
        Task<List<GroupingModel>> GetSubProgramDataForYear(int year, string ministry, string program, string username);
        Task<List<GroupingModel>> GetAccountTypeDataForYear(int year, string ministry, string program, string subprogram, string username);
        Task<List<GroupingModel>> GetAccountDataForYear(int year, string ministry, string program, string subprogram, string accountType, string username);
        Task<List<BudgetEstimatesModel>> GetDataForYear(int year, string ministry, string program, string subprogram, string account, string username);
        Task<List<ListItemModel>> GetDependantMinistries(string username);
        Task<List<ListItemModel>> GetDependantPrograms(string ministry, string username);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string program, string username);
        Task<List<ListItemModel>> GetDependantSubPrograms(string ministry, string username);
        Task<List<ListItemModel>> GetDependantAccountTypes(string ministry, string program, string subprogram, string username);
        Task<List<ListItemModel>> GetDependantAccounts(string ministry, string program, string subprogram, string acctype, string username);
        Task<List<ListItemModel>> GetEnteredAccounts(int year, string ministry, string program, string subprogram, string acctype);
        Task<int> AddNewRecEntry(BudgetEstimatesModel bem);
        Task<int> RemoveRecEntry(int id);
        Task<int> UpdateRecEntry(BudgetEstimatesModel bem);
        Task<int> SetRecEntryStatus(int pyear, string subprog, int status);
        Task<int> GetSubProgramStatus(int pyear, string subprog);
        Task<List<ListItemModel>> GetAllSubPrograms();
        Task<List<GroupingModel>> GetSOCDataForYear(int year, string username);
        Task<List<GroupingModel>> GetSOCMinDataForYear(int year, string soc, string username);
        Task<List<GroupingModel>> GetSOCProgramDataForYear(int year, string soc, string ministry, string username);
        Task<List<GroupingModel>> GetSOCSubProgramDataForYear(int year, string soc, string ministry, string program, string username);
        Task<List<GroupingModel>> GetSOCAccountDataForYear(int year, string ministry, string program, string subprogram, string accountType, string username);
    }
}