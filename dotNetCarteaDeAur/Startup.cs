using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dotNetCarteaDeAur.Startup))]
namespace dotNetCarteaDeAur
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
