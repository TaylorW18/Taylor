using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CalorieCount.StartupOwin))]

namespace CalorieCount
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
