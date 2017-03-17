using AutoMapper;

namespace CarSystem.Web.Infrastucture.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
