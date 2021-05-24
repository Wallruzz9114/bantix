using AutoMapper;
using Core.ViewModels;
using Data.Entities;

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