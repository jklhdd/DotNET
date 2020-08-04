using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthenticateASP.Startup))]
namespace AuthenticateASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
