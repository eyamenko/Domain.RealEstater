using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;
using ServiceNetCore;
using System.Threading;

namespace Domain.RealEstater.Service.Workers
{
    public class PropertyWorker : Worker
    {
        private const int RunEvery = 2000;

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
            _timer = new Timer(Callback);
            _timer.Change(RunEvery, RunEvery);
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