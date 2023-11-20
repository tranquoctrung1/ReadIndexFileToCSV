using ReadIndexFileToCSV.Actions;
using ReadIndexFileToCSV.Contollers;
using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {
            // Usage:
            var handle = GetConsoleWindow();

            int console = int.Parse(ConfigurationManager.AppSettings["console"]);

            // Hide
            ShowWindow(handle, console);

            string macAdress = "40F2E9DA8012";

            String firstMacAddress = NetworkInterface
               .GetAllNetworkInterfaces()
               .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
               .Select(nic => nic.GetPhysicalAddress().ToString())
               .FirstOrDefault();

            if (macAdress == firstMacAddress)
            {
                MainController main = new MainController();

                main.run();
            }
            else
            {
                WriteLogAction writeLogAction = new WriteLogAction();
                writeLogAction.WriteErrorLog("Wrong MA").Wait();
            }
        }
    }
}
