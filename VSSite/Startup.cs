using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VSSite.Startup))]
namespace VSSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
