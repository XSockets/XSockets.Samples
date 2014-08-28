using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using XSockets.Core.Configuration;

namespace XSockets.Windows.Service.Host
{
    /// <summary>
    /// Get the XSockets.NET Server configuration
    /// </summary>
    public class ConfigurationLoader : ConfigurationSetting
    {
        public ConfigurationLoader()
        {
            Uri = GetUri(ConfigurationManager.AppSettings["XSockets.Url"]);
            Origin = new HashSet<string>(ConfigurationManager.AppSettings["XSockets.Origins"].Split(',').ToArray());                        
        }

        public Uri GetUri(string location)
        {
            try
            {
                return new Uri(location);
            }
            catch (Exception)
            {

                return new Uri(string.Format("ws://{0}", location));
            }

        }
    }
}