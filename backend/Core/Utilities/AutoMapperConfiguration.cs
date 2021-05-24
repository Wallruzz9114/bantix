using AutoMapper;
using Core.Mappings;

namespace Core.Utilities
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(p =>
            {
                p.AddProfile(new EntitiesToViewModelsMappingProfiles());
                p.AddProfile(new ViewModelsToEntitiesMappingProfiles());
            });
        }
    }
}