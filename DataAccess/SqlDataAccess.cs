using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess, IDisposable
    {
        private readonly IConfiguration _config;
        private string ConnectionStringName { get; set; } = "Default";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> GetListData<T, U>(string sql, U parameters)
        {

            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }


        }

        public async Task<T> GetSingleValueData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.ExecuteScalarAsync<T>(sql, parameters);
                return data;
            }
        }

        public async Task<T> GetSingleRowData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QuerySingleAsync<T>(sql, parameters);
                return data;
            }
        }

        public async Task<int> ExecuteSql<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.ExecuteAsync(sql, parameters);
                return data;
            }
        }
        public async Task ExecuteSP(string spName, object parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(spName,parameters,commandType: CommandType.StoredProcedure);                
            }
        }


        public Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultipleDataSets<T1, T2>(string sql, object parameters,
                                         Func<GridReader, IEnumerable<T1>> func1,
                                         Func<GridReader, IEnumerable<T2>> func2)
        {
            var objs = getMultiple(sql, parameters, func1, func2);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultipleDataSets<T1, T2, T3>(string sql, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3)
        {
            var objs = getMultiple(sql, parameters, func1, func2, func3);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>, objs[2] as IEnumerable<T3>);
        }

        private List<object> getMultiple(string sql, object parameters, params Func<GridReader, object>[] readerFuncs)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            var returnResults = new List<object>();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var gridReader = connection.QueryMultiple(sql, parameters);

                foreach (var readerFunc in readerFuncs)
                {
                    var obj = readerFunc(gridReader);
                    returnResults.Add(obj);
                }
            }

            return returnResults;
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void StartTransaction()
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open(); 
            _transaction = _connection.BeginTransaction();

        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
        }

        public void RollbackTransaction()
        { 
            _transaction?.Rollback();
            _connection?.Close();
        }

        public void Dispose()
        {
            CommitTransaction();
        }

        public async Task<int> SaveDataInTransaction<T>(string sql, T parameters)
        {          
            var data = await _connection.ExecuteAsync(sql, parameters, transaction: _transaction);
            return data;
        }

        public async Task<List<T>> GetListDataInTransaction<T, U>(string sql, U parameters)
        {

                var data = await _connection.QueryAsync<T>(sql, parameters, transaction:_transaction);
                return data.ToList();

        }

    }
}
