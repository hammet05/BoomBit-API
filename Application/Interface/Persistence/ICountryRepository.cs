using TestBoomBit.Application.DTO;
using TestBoomBit.Common;
using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.Interface.Persistence
{
    public interface ICountryRepository
    {
        Task<bool> Create(Country country);
        Task<IEnumerable<Country>> GetAll();
    }
}
