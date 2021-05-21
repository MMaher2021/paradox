using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GetDOCStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RailComm DOC External Interface Service: "       + GetWindowsServiceStatus("RailComm DOC External Interface Service"));
            Console.WriteLine("RailComm DOC Communications Service: "           + GetWindowsServiceStatus("RailComm DOC Communications Service"));
            Console.WriteLine("RailComm DOC Message Dispatcher Service: "       + GetWindowsServiceStatus("RailComm DOC Message Dispatcher Service"));
            Console.WriteLine("RailComm DOC Server Service: "                   + GetWindowsServiceStatus("RailComm DOC Server Service"));
            Console.WriteLine("RailComm DOC System Launcher Service: "          + GetWindowsServiceStatus("RailComm DOC System Launcher Service"));
            Console.WriteLine("RailComm DOC System State Controller Service: "  + GetWindowsServiceStatus("RailComm DOC System State Controller Service"));
        }

        public static String GetWindowsServiceStatus(String serviceName)
        {

            try
            {
                ServiceController sc = new ServiceController(serviceName);

                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return "Running";
                    case ServiceControllerStatus.Stopped:
                        return "Stopped";
                    case ServiceControllerStatus.Paused:
                        return "Paused";
                    case ServiceControllerStatus.StopPending:
                        return "Stopping";
                    case ServiceControllerStatus.StartPending:
                        return "Starting";
                    default:
                        return "Status Changing";
                }
            }
            catch (Exception ex)
            {
                return "Not Found";
            }
        }

    }
}
