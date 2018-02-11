using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndexCard.Startup))]
namespace IndexCard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
