using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRecEstimateData
    {
        Task<List<BudgetEstimateEntryModel>> GetDataForYear(int year);
        Task<List<GroupingModel>> GetMinDataForYear(int year);
        Task<List<GroupingModel>> GetProgramDataForYear(int year, string ministry);
        Task<List<GroupingModel>> GetSubProgramDataForYear(int year, string ministry, string program);
    }
}