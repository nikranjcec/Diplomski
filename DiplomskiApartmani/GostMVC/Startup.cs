using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GostMVC.Startup))]
namespace GostMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
