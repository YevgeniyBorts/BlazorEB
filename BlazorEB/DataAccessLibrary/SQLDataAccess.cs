using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        public SQLDataAccess(IConfiguration config)
        {
            Config = config;
        }

        public string ConnectionStringName { get; set; } = "Default";

        public IConfiguration Config { get; }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = Config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = Config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
            {

            }
        }
    }
}
