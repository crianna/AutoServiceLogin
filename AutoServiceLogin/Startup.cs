using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoServiceLogin.Startup))]
namespace AutoServiceLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
