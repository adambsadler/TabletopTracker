using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TabletopTracker.WebMVC.Startup))]
namespace TabletopTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
