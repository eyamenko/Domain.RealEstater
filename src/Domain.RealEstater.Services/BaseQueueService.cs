using System.Threading.Tasks;

namespace Domain.RealEstater.Services
{
    public class BaseQueueService<T>
    {
        public async Task Push(T message)
        {
            
        }

        public async Task<T> Peek()
        {
            
        }
    }
}