using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MioBarber.Startup))]
namespace MioBarber
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
