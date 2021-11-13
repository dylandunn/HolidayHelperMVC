using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HolidayHelper.WebMVC.Startup))]
namespace HolidayHelper.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
