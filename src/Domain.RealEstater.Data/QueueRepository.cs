using System;
using System.Threading.Tasks;
using Dapper;
using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Data
{
    public class QueueRepository : IQueueRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public QueueRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task Push<T>(string queue, QueueItem<T> queueItem)
        {
            var sql = $@"INSERT INTO {queue}
                             (Id, Message)
                         VALUES
                             (UNHEX(@IdStr), @MessageStr)";

            using (var connection = _connectionFactory.Get())
            {
                await connection.ExecuteAsync(sql, queueItem);
            }
        }

        public async Task<QueueItem<T>> Peek<T>(string queue)
        {
            var sql = $@"SELECT
                             HEX(Id) AS IdStr, Message AS MessageStr
                         FROM
                             {queue}
                         WHERE
                             Dequeued = 0
                         LIMIT 1";

            using (var connection = _connectionFactory.Get())
            {
                return await connection.QueryFirstOrDefaultAsync<QueueItem<T>>(sql);
            }
        }

        public async Task MarkAsDequeued(string queue, Guid id)
        {
            var sql = $@"UPDATE
                             {queue}
                         SET
                             Dequeued = 1
                         WHERE
                             Id = UNHEX(@id)";

            using (var connection = _connectionFactory.Get())
            {
                await connection.ExecuteAsync(sql, new {id = id.ToString("N")});
            }
        }
    }
}