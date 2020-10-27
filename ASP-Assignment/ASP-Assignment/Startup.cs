using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_Assignment.Startup))]
namespace ASP_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
