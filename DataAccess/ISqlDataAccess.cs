
namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadListData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task<T> LoadData<T, U>(string sql, U parameters);
    }
}