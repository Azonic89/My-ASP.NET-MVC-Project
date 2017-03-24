namespace CarSystem.Web.Infrastucture.Contracts
{
    public interface IMappingService
    {
        TDestination Map<TDestination>(object source);
    }
}
