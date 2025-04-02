using AutoMapper;
using TestBoomBit.Application.DTO;
using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Activity, ActivitiesDto>().ReverseMap();
            CreateMap<Country, CountriesDto>().ReverseMap();

        }
    }
}
