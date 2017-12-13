using System.Data;

namespace Domain.RealEstater.Contracts.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Get();
    }
}