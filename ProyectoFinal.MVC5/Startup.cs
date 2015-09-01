using Microsoft.Owin;
using Owin;
using ProyectoFinal.MVC5;

[assembly: OwinStartup(typeof(Startup))]
namespace ProyectoFinal.MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
