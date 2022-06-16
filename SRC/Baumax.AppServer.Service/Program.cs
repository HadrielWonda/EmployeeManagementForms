//#define DEBUGGING

using System.ServiceProcess;

namespace Baumax.AppServer.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUGGING
            if(System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }
            else
            {
                System.Diagnostics.Debugger.Launch();
            }
#endif
            ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] {new BaumaxAppServerService()};

            ServiceBase.Run(ServicesToRun);
        }
    }
}