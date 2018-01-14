using AutoMapper;
using SWOF.Core.Models;
using SWOF.Core.Resources;

namespace SWOF.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to Resource
            CreateMap<Engineer, EngineerModel>();

            // Resource to Entity
            CreateMap<EngineerModel, Engineer>();
        }
    }
}
