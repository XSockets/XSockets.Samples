using Owin;
using XSockets.Owin.Host;

namespace StockServer
{
    /// <summary>
    /// Owin startup, use static files and also XSockets.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.UseStaticFiles("/Sample/Web");
            
            app.UseXSockets(true);
        }
    }
}