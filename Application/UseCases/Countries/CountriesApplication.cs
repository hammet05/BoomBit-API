using AutoMapper;
using System.Diagnostics.Metrics;
using TestBoomBit.Application.DTO;
using TestBoomBit.Application.Interface.Application;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Common;
using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.UseCases.Countries
{
    public class CountriesApplication : ICountryApplication
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CountriesApplication(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Create(CountriesDto countriesDto)
        {
            var country = _mapper.Map<Country>(countriesDto);
            var result= await _unitOfWork!.Countries!.Create(country);

            return new Response<bool> { Data = result, Success = result, Message="Registro creado satisfactoriamente" };
        }

        public async Task<Response<IEnumerable<CountriesDto>>> GetAll()
        {
            var countries = await _unitOfWork!.Countries!.GetAll();
            var mappedCountries = _mapper.Map<IEnumerable<CountriesDto>>(countries); 

            return new Response<IEnumerable<CountriesDto>>
            {
                Data = mappedCountries,
                Success = mappedCountries.Any(),
                Message = "Paises encontrados satisfactoriamente"
            };
        }
    }
}
