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

    }
}