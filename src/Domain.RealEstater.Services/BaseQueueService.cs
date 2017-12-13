using System;
using System.Threading.Tasks;
using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Services
{
    public abstract class BaseQueueService<T>
    {
        private readonly IQueueRepository _queueRepository;

        protected BaseQueueService(IQueueRepository queueRepository)
        {
            _queueRepository = queueRepository;
        }

        protected abstract string Queue { get; }

        public async Task Push(T message)
        {
            var queueItem = new QueueItem<T>
            {
                Id = Guid.NewGuid(),
                Message = message
            };

            await _queueRepository.Push(Queue, queueItem);
        }

        public async Task<T> Peek()
        {
            var queueItem = await _queueRepository.Peek<T>(Queue);

            if (queueItem == null)
            {
                return default(T);
            }

            await _queueRepository.MarkAsDequeued(Queue, queueItem.Id);

            return queueItem.Message;
        }
    }
}