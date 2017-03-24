using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;
using Ninject.Web.Common;

using CarSystem.Data;
using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;

namespace CarSystem.Web.App_Start.NinjecModuleBindings
{
    public class DataBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindAllClasses);
            this.Bind<ICarSystemEfDbContextSaveChanges>().To<CarSystemDbContextSaveChanges>().InRequestScope();

        }

        private void BindAllClasses(IFromSyntax bindings)
        {
            bindings
                .FromAssembliesMatching("CarSystem.Data.dll")
                .SelectAllClasses()
                .BindDefaultInterface()
                .ConfigureFor<CarSystemEfDbContext>(c => c.InRequestScope());
        }
    }
}