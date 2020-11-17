using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyecto2_1.Startup))]
namespace proyecto2_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
