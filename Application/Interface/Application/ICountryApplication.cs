
using TestBoomBit.Application.DTO;
using TestBoomBit.Common;

namespace TestBoomBit.Application.Interface.Application
{
    public interface ICountryApplication
    {
        Task<Response<IEnumerable<CountriesDto>>> GetAll();
        Task<Response<bool>> Create(CountriesDto countriesDto);

    }
}
