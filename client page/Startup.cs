using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(client_page.Startup))]
namespace client_page
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
