using Domain.RealEstater.Contracts.Matchers;

namespace Domain.RealEstater.Matchers
{
    public class MatcherFactory : IMatcherFactory
    {
        public IPropertyMatcher Get(string agencyCode)
        {
            throw new System.NotImplementedException();
        }
    }
}