using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogProject42020.Startup))]
namespace BlogProject42020
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
