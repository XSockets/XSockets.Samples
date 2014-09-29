using XSockets.Core.Configuration;

namespace ScalingAndPerformanceSample.ServerB.Configuration
{
    public class CustomConfig : ConfigurationSetting
    {
        public CustomConfig() : base("ws://127.0.0.1:4504")
        {
            
        }
    }
}