using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPSecurity.Startup))]
namespace ASPSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
