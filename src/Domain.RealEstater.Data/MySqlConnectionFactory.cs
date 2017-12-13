using System;
using System.Data;
using Domain.RealEstater.Contracts.Data;
using MySql.Data.MySqlClient;

namespace Domain.RealEstater.Data
{
    public class MySqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public MySqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Get()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}