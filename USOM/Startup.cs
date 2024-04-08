using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(USOM.Startup))]
namespace USOM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
