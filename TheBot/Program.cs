using Common.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Noobot.Core;
using Noobot.Core.Configuration;
using Noobot.Core.DependencyResolution;
using System;
using System.Threading;
using System.Threading.Tasks;
using TheBot.Logging;

namespace TheBot
{
    public class Program
    {
        private static INoobotCore _noobotCore;
        private static readonly ManualResetEvent _quitEvent = new ManualResetEvent(false);

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Noobot...");
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit; // closing the window doesn't hit this in Windows
            Console.CancelKeyPress += Console_CancelKeyPress;

            RunNoobot()
                .GetAwaiter()
                .GetResult();

            BuildWebHost(args).Run();

            _quitEvent.WaitOne();
        }

        private static ConsoleOutLogger GetLogger() => new ConsoleOutLogger("Noobot", LogLevel.All, true, true, false, "yyyy/MM/dd HH:mm:ss:fff");

        private static async Task RunNoobot()
        {
            var containerFactory = new ContainerFactory(
                new ConfigurationBase(),
                new JsonConfigReader(@"noobotconfig.json"),
                GetLogger());

            INoobotContainer container = containerFactory.CreateContainer();
            _noobotCore = container.GetNoobotCore();

            await _noobotCore.Connect();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _quitEvent.Set();
            e.Cancel = true;
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("Disconnecting...");
            _noobotCore?.Disconnect();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
