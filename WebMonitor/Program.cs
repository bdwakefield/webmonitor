using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace WebMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var ping = new Ping();
            while (true)
            {
                try
                {
                    var result = ping.SendPingAsync("google.com", 1000).Result;

                    while (result.Status == IPStatus.Success)
                    {
                        Console.WriteLine($"{DateTime.Now:yyyyMMdd hh:mm:ss.fff} Alive!");
                        Thread.Sleep(1000);
                        result = ping.SendPingAsync("google.com", 1000).Result;
                    }
                    
                    Console.WriteLine($"{DateTime.Now:yyyyMMdd hh:mm:ss.fff} Dead! {result.Status}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{DateTime.Now:yyyyMMdd hh:mm:ss.fff} Dead! - {e.Message}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}