using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Contracts.Data
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllNotAdvertised();
        Task<IEnumerable<Property>> GetAllAdvertised();
        Task SetAdvertised(Property property);
    }
}