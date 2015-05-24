using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinosPark.Web.Startup))]
namespace SinosPark.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
