using XSockets.Core.XSocket;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;

namespace StockServer.Sample.Controllers
{
    /// <summary>
    /// An XSockets longrunning controller.
    /// A longrunning controller cant be connected to.
    /// It will work inside the server as a longrunning process...
    /// Perfect for collecting data or similar and then occationally send info over to other public controllers
    /// </summary>
    [XSocketMetadata("StockTicker", PluginRange.Internal)]
    public class StockTickerController : XSocketController
    {
        //The controller to send data to when the OnTick event fires
        private readonly StockController StockController = new StockController();

        public StockTickerController()
        {
            //New ticker... with the action for tick
            new Model.StockTicker((stock) => StockController.Tick(stock));
        }
    }
}
