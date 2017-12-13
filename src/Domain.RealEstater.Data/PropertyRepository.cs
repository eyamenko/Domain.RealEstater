using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Data
{
    public class PropertyRepository : IPropertyRepository
    {
        private const string PROPERTIES = "properties";

        private readonly IConnectionFactory _connectionFactory;

        public PropertyRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Property>> GetAllNotAdvertised()
        {
            var sql = $@"SELECT
                             *
                         FROM
                             {PROPERTIES}
                         WHERE
                             Advertised = 0";

            using (var connection = _connectionFactory.Get())
            {
                return await connection.QueryAsync<Property>(sql);
            }
        }

        public async Task<IEnumerable<Property>> GetAllAdvertised()
        {
            var sql = $@"SELECT
                             *
                         FROM
                             {PROPERTIES}
                         WHERE
                             Advertised = 1";

            using (var connection = _connectionFactory.Get())
            {
                return await connection.QueryAsync<Property>(sql);
            }
        }

        public async Task SetAdvertised(Property property)
        {
            var sql = $@"UPDATE
                             {PROPERTIES}
                         SET
                             Advertised = 1
                         WHERE
                             Latitude = @Latitude
                         AND
                             Longitude = @Longitude";

            using (var connection = _connectionFactory.Get())
            {
                await connection.ExecuteAsync(sql, property);
            }
        }
    }
}