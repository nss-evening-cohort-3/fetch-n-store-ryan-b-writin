using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FetchNStore.Startup))]
namespace FetchNStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
