using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;

namespace CarSystem.Web.App_Start.NinjecModuleBindings
{
    public class DataServicesBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindAllClasses);
        }

        private void BindAllClasses(IFromSyntax bindings)
        {
            bindings
                .FromAssembliesMatching("*.Data.Services.*")
                .SelectAllClasses()
                .BindDefaultInterface();
        }
    }
}