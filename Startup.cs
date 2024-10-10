using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.net_vidly.Startup))]
namespace asp.net_vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
