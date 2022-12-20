
using static Dapper.SqlMapper;

namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        Task<T> GetSingleRowData<T, U>(string sql, U parameters);
        Task<List<T>> GetListData<T, U>(string sql, U parameters);
        Task<int> ExecuteSql<T>(string sql, T parameters);
        Task ExecuteSP(string spName, object parameters);
        Task<T> GetSingleValueData<T, U>(string sql, U parameters);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultipleDataSets<T1, T2, T3>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultipleDataSets<T1, T2>(string sql, object parameters,
                                 Func<GridReader, IEnumerable<T1>> func1,
                                 Func<GridReader, IEnumerable<T2>> func2);
        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task<int> SaveDataInTransaction<T>(string sql, T parameters);
        Task<List<T>> GetListDataInTransaction<T, U>(string sql, U parameters);
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

/*******
 * Example usage transaction
 * 
 *using (SqlDataAccess sql = new SqlDataAccess())
 *{
 *try{
 *sql.StartTransaction();
 *sql.SaveDataIntTransaction(xxx,xx)
 *sql.LoadDataInTransaction(xx,xx)
 *sql.CommitTransaction();
 *}
 *catch {sql.RollbackTransaction;
 *throw}
 *}
 * 
 * ********/