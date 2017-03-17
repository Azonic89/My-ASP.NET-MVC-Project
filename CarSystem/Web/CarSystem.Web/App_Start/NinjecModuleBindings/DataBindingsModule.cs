using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;
using Ninject.Web.Common;

using CarSystem.Data;

namespace CarSystem.Web.App_Start.NinjecModuleBindings
{
    public class DataBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindAllClasses);
        }

        private void BindAllClasses(IFromSyntax bindings)
        {
            bindings
                .FromAssembliesMatching("CarSystem.Data.dll")
                .SelectAllClasses()
                .BindDefaultInterface()
                .ConfigureFor<CarSystemDbContext>(c => c.InRequestScope());
        }
    }
}