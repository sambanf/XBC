using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinPro180.MVC.Startup))]
namespace MinPro180.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
