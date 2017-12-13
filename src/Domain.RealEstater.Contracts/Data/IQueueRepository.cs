using System;
using System.Threading.Tasks;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Contracts.Data
{
    public interface IQueueRepository
    {
        Task Push<T>(string queue, QueueItem<T> queueItem);
        Task<QueueItem<T>> Peek<T>(string queue);
        Task MarkAsDequeued(string queue, Guid id);
    }
}