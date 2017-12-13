using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;
using ServiceNetCore;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.RealEstater.Service.Workers
{
    public class PropertyWorker : Worker
    {
        private const int OneSecond = 1000;

        private readonly IQueueService<Property> _queueService;
        private readonly IPropertyService _propertyService;

        private Timer _timer;

        public PropertyWorker(IQueueService<Property> queueService, IPropertyService propertyService)
        {
            _queueService = queueService;
            _propertyService = propertyService;
        }

        public override void Start()
        {
            _timer = new Timer(_ => Callback().GetAwaiter().GetResult());
            _timer.Change(OneSecond, OneSecond);
        }

        public override void Stop()
        {
            _timer.Dispose();
        }

        private async Task Callback()
        {
            var property = await _queueService.Peek();

            if (property == null)
            {
                return;
            }

            await _propertyService.Match(property);
        }
    }
}