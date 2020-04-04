using AutoMapper;
using uangsaku.Application.ViewModels;
using uangsaku.Domain.Models;

namespace uangsaku.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
