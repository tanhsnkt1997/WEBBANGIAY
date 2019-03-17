using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shopxanh.Startup))]
namespace shopxanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
