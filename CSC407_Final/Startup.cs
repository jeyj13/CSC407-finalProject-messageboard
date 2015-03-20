using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC407_Final.Startup))]
namespace CSC407_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
