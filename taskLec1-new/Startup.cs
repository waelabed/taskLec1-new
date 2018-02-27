using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(taskLec1_new.Startup))]
namespace taskLec1_new
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
