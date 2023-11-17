using ReadIndexFileToCSV.Actions;
using ReadIndexFileToCSV.Contollers;
using ReadIndexFileToCSV.Models;
using System;
using System.Collections.Generic;
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


        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            // Usage:
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

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
