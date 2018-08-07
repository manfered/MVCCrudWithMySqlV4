using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCrudWithMySqlV4.Startup))]
namespace MVCCrudWithMySqlV4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
