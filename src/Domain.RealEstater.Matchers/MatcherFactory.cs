using System.Collections.Generic;
using System.Linq;
using Domain.RealEstater.Contracts.Matchers;

namespace Domain.RealEstater.Matchers
{
    public class MatcherFactory : IMatcherFactory
    {
        private readonly IEnumerable<IPropertyMatcher> _propertyMatchers;

        public MatcherFactory(IEnumerable<IPropertyMatcher> propertyMatchers)
        {
            _propertyMatchers = propertyMatchers;
        }

        public IPropertyMatcher Get(string agencyCode)
        {
            return _propertyMatchers.FirstOrDefault(m => m.AgencyCode == agencyCode);
        }
    }
}