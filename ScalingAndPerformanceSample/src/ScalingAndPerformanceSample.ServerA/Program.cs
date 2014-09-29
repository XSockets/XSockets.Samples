using System;
using XSockets.Core.Common.Enterprise;
using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework;

namespace ScalingAndPerformanceSample.ServerA
{
    class Program
    {
        static void Main(string[] args)
        {            
            using (var container = Composable.GetExport<IXSocketServerContainer>())
            {
                Composable.GetExport<IXSocketsScaleOut>().AddScaleOut("ws://127.0.0.1:4504");
                Composable.GetExport<IXSocketsScaleOut>().AddScaleOut("ws://127.0.0.1:4505");
                Composable.GetExport<IXSocketsScaleOut>().AddScaleOut("ws://127.0.0.1:4506");
                container.Start();
                Console.ReadLine();
            }
        }
    }
}
