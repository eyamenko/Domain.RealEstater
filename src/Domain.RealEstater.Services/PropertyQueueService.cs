using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Services
{
    public class PropertyQueueService : BaseQueueService<Property>, IQueueService<Property>
    {
        public PropertyQueueService(IQueueRepository queueRepository) : base(queueRepository)
        {
        }

        protected override string Queue => "property_queue";
    }
}