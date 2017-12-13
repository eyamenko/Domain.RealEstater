using System.Threading.Tasks;

namespace Domain.RealEstater.Contracts.Services
{
    public interface IQueueService<T>
    {
        Task Push(T message);
        Task<T> Peek();
    }
}