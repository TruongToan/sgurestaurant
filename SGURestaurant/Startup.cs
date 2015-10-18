using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGURestaurant.Startup))]
namespace SGURestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
