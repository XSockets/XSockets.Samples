using Owin;

namespace XSockets.IoT.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseStaticFiles("/Web");                           
        }
    }
}
