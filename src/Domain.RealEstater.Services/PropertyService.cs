using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Contracts.Matchers;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IMatcherFactory _matcherFactory;
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IMatcherFactory matcherFactory, IPropertyRepository propertyRepository)
        {
            _matcherFactory = matcherFactory;
            _propertyRepository = propertyRepository;
        }

        public async Task<bool> Match(Property property)
        {
            var matcher = _matcherFactory.Get(property.AgencyCode);

            if (matcher == null)
            {
                return false;
            }

            var allNotAdvertised = await _propertyRepository.GetAllNotAdvertised();

            foreach (var naProperty in allNotAdvertised)
            {
                if (matcher.IsMatch(property, naProperty))
                {
                    await _propertyRepository.SetAdvertised(naProperty);

                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<Property>> GetAllAdvertised()
        {
            return await _propertyRepository.GetAllAdvertised();
        }
    }
}