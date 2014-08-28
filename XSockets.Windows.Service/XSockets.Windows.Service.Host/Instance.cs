using System.Collections.Generic;
using XSockets.Core.Common.Configuration;
using XSockets.Core.Common.Socket;

namespace XSockets.Windows.Service.Host
{
    public class Instance
    {
        public IXSocketServerContainer wss { get; set; }

        public Instance()
        {
            wss = Plugin.Framework.Composable.GetExport<IXSocketServerContainer>();
            wss.Start(withInterceptors:true, configurationSettings: new List<IConfigurationSetting>{ new ConfigurationLoader()});
        }

    }
}
