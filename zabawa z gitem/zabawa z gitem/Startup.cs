using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(zabawa_z_gitem.Startup))]
namespace zabawa_z_gitem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
