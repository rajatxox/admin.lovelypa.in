using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admin_lovelypa_in.Startup))]
namespace admin_lovelypa_in
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
