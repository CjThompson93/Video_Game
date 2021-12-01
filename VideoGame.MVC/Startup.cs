using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoGame.MVC.Startup))]
namespace VideoGame.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
