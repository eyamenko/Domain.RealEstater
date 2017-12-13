using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Contracts.Services
{
    public interface IPropertyService
    {
        Task<bool> Match(Property property);
        Task<IEnumerable<Property>> GetAllAdvertised();
    }
}