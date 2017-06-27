using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentsDemoEF.Startup))]
namespace StudentsDemoEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
