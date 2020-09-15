using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmGorena.Startup))]
namespace AdmGorena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
