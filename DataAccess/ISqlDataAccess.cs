
using static Dapper.SqlMapper;

namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        Task<T> GetSingleData<T, U>(string sql, U parameters);
        Task<List<T>> GetListData<T, U>(string sql, U parameters);
        Task ExecuteSql<T>(string sql, T parameters);
        Task<T> GetData<T, U>(string sql, U parameters);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultipleDataSets<T1, T2, T3>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultipleDataSets<T1, T2>(string sql, object parameters,
                                 Func<GridReader, IEnumerable<T1>> func1,
                                 Func<GridReader, IEnumerable<T2>> func2);
    }
}

/*******
 * Example usage get multiple
 * 
 *  var sql = "select * from Foo; select * from Bar";
            var foosAndBars = this.GetMultipleDataSets(sql, new { param = "baz" }, gr => gr.Read<Foo>(), gr => gr.Read<Bar>());
            var foos = foosAndBars.Item1;
            var bars = foosAndBars.Item2;
 * 
 * ********/