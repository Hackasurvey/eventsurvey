using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mysurveyaspnet4.Startup))]
namespace mysurveyaspnet4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
