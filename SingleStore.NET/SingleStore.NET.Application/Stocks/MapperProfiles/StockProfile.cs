using AutoMapper;
using SingleStore.NET.Domain.Entities;

namespace SingleStore.NET.Application.ViewModels.MapperProfiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockViewModel>();
            //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<StockViewModel, Stock>();
        }
    }
}
