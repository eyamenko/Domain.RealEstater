namespace Domain.RealEstater.Contracts.Matchers
{
    public interface IMatcherFactory
    {
        IPropertyMatcher Get(string agencyCode);
    }
}