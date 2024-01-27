using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MonitoringTask
{
    static class Program
    {
        static void Main(string[] args)
        {
            var systeminfo = new SystemInfo();
            string cpuCounter = String.Empty;
            string ramCounter = String.Empty;

            var threadGetCpu = new Thread(() =>
            {
                while(true)
                {
                    cpuCounter = systeminfo.GetCpu();
                    Thread.Sleep(1000);
                }
            });

            var threadGetRam = new Thread(() =>
            {
                while(true)
                {
                    ramCounter = systeminfo.GetRam();
                    Thread.Sleep(500);
                }
            });

            threadGetCpu.Start();
            threadGetRam.Start();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(cpuCounter);
                Console.WriteLine(ramCounter);
                Thread.Sleep(800);
            }
        }
    }
}