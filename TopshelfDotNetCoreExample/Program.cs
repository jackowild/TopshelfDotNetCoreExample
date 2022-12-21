using Serilog;
using System.Timers;
using Topshelf;

namespace TopshelfDotNetCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(windowsService =>
            {
                // this is test code example 
                windowsService.Service<ServiceExample>(s =>
                {
                    s.ConstructUsing(service => new ServiceExample());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });

                windowsService.RunAsLocalSystem();
                windowsService.StartAutomatically();

                windowsService.SetDescription("TopshelfDotNetCoreExample");
                windowsService.SetDisplayName("TopshelfDotNetCoreExample");
                windowsService.SetServiceName("TopshelfDotNetCoreExample");
            });
        }
    }

    class ServiceExample
    {
        private Timer timer;
        private int count;

        public ServiceExample()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\LogFiles\\TopshelfDotNetCoreExample\\log.txt")
                .CreateLogger();

            this.timer = new Timer() { AutoReset = true, Interval = 30000 };
            this.timer.Elapsed += (s, e) => Log.Information($"Count = {this.count++}");
        }

        public void Start()
        {
            Log.Information("Started");
            this.timer.Start();
        }

        public void Stop()
        {
            Log.Information("Stopped");
            this.timer.Stop();
        }
    }
}
