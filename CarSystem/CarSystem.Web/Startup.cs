using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarSystem.Web.Startup))]
namespace CarSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
