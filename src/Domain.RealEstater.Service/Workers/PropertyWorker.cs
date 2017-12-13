using System.Threading;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;
using ServiceNetCore;

namespace Domain.RealEstater.Service.Workers
{
    public class PropertyWorker : Worker
    {
        private const int RUN_EVERY = 2000;

        private readonly IPropertyService _propertyService;
        private readonly IQueueService<Property> _queueService;

        private Timer _timer;

        public PropertyWorker(IQueueService<Property> queueService, IPropertyService propertyService)
        {
            _queueService = queueService;
            _propertyService = propertyService;
        }

        public override void Start()
        {
            _timer = new Timer(Callback);
            _timer.Change(0, RUN_EVERY);
        }

        public override void Stop()
        {
            _timer.Dispose();
        }

        private async void Callback(object state)
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