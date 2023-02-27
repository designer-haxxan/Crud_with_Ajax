using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crud_with_Ajax.Startup))]
namespace Crud_with_Ajax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
