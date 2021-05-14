using AutoMapper;
using Core.ViewModels;
using Data.Entities;

namespace Core.Mappings
{
    public class EntitiesToViewModelsMappingProfiles : Profile
    {
        public EntitiesToViewModelsMappingProfiles()
        {
            CreateMap<Agency, AgencyViewModel>();
            CreateMap<AgencyViewModel, Agency>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}