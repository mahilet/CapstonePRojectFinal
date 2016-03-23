using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MahaletWebsiteMVC.Startup))]
namespace MahaletWebsiteMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
