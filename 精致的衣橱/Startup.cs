using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(精致的衣橱.Startup))]
namespace 精致的衣橱
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
