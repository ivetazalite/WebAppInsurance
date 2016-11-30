using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Training.Programming.FinalTask.Startup))]
namespace Training.Programming.FinalTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
