using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json;
using TCP.BusinessLogic;
using TCP.BusinessLogic.Components;
using TCP.BusinessLogic.Repository;
using TCP.Contract;
using TCP.Contract.Components;
using TCP.Contract.Repository;
using TCP.Model;
using TCP.Server;

namespace TCPSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            host.Services.GetService<IServerProvider>().Start();
        }


        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
               services.AddSingleton<IServerProvider, TCPServer>()
               .AddSingleton<ICommandExecuter, CommandExecuter>()
                   .AddSingleton<IDeviceManager, DeviceManager>()
               .AddSingleton<IDeviceRepository, DeviceRepository>()
               );
    }
}
