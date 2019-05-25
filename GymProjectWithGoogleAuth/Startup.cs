using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymProjectWithGoogleAuth.Startup))]
namespace GymProjectWithGoogleAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
