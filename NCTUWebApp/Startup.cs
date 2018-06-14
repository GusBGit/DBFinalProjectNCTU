using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NCTUWebApp.Startup))]
namespace NCTUWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
