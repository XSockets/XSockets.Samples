﻿using System.ServiceProcess;

namespace XSockets.Windows.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Initializer() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
