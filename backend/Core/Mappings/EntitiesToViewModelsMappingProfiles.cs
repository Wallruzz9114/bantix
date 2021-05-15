using AutoMapper;
using Data.Entities;
using Data.ViewModels;

namespace Core.Mappings
{
    public class EntitiesToViewModelsMappingProfiles : Profile
    {
        public EntitiesToViewModelsMappingProfiles()
        {
            CreateMap<Agent, AgentViewModel>();
            CreateMap<AgentViewModel, Agent>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}