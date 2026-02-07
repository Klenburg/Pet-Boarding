using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetBoardingApp.Startup))]
namespace PetBoardingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
