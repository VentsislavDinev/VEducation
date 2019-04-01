using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VEducation.Web.Startup))]
namespace VEducation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
