using System;
using XSockets.Core.Common.Socket;

namespace XSockets.IoT.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();
                Console.ReadLine();
            }
        }
    }
}
