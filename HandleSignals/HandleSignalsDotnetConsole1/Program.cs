using System;
using System.Diagnostics;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Mono.Unix;
using Mono.Unix.Native;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Application started. Press Ctrl+C to exit.");

        // Hook up signal handlers
        AssemblyLoadContext.Default.Unloading += ctx => HandleSignal("SIGTERM");
        Console.CancelKeyPress += (sender, eventArgs) =>
        {
            HandleSignal("SIGINT");
            eventArgs.Cancel = true; // Prevent immediate termination
        };

        // Handle SIGQUIT explicitly
        UnixSignal[] signals = new UnixSignal[]
        {
            new UnixSignal(Signum.SIGQUIT),
        };

        // Run signal listening as a background task
        _ = Task.Run(() =>
        {
            while(true)
            {
              signals[0].WaitOne();
              HandleSignal("SIGQUIT");
            }
        });

        // Keep application running asynchronously
        await RunConsoleAsync();
    }

    static async Task RunConsoleAsync()
    {
        while (true)
        {
            Console.WriteLine($"Working {Process.GetCurrentProcess().Id}");
            await Task.Delay(5000); // Simulated asynchronous work
        }
    }

    static void HandleSignal(string signalName)
    {
        if (signalName == "SIGTERM")
        {
            Console.WriteLine("Signal received: SIGTERM");
            Console.WriteLine("Shutting down gracefully...");
            Process.GetCurrentProcess().Kill();
        }
        else
        {
            Console.WriteLine($"Signal {signalName} ignored.");
        }
    }
}
