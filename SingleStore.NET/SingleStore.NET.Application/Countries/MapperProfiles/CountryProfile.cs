using AutoMapper;
using SingleStore.NET.Domain.Entities;

namespace SingleStore.NET.Application.ViewModels.MapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();
        }
    }
}
