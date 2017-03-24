using AutoMapper;

using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Infrastucture
{
    public class MappingService : IMappingService
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
