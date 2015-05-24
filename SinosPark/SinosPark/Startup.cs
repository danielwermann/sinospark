using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinosPark.Startup))]
namespace SinosPark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
