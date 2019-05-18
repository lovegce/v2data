﻿using System;
using System.IO;
using DataGetter.Services;
using DataGetter.Services.Impl;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using V2Ray.Core.App.Stats.Command;

namespace DataGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.UseConsoleLifetime()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((host, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", true);
                config.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", true);
                config.AddEnvironmentVariables(prefix: "APP_");
                config.AddCommandLine(args);
            })
            .ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
                configHost.AddJsonFile("hostsettings.json", optional: true);
                configHost.AddEnvironmentVariables(prefix: "APPHOST");
                configHost.AddCommandLine(args);
            }).ConfigureLogging(loggerBuilder =>
            {
                loggerBuilder.AddConsole();
                loggerBuilder.AddDebug();
            }).ConfigureServices(services =>
            {
                services.AddHttpClient();
                services.AddLogging();
                services.AddSingleton<StatsService.StatsServiceClient>(provider =>
                {
                    IConfiguration config = provider.GetRequiredService<IConfiguration>();
                    string host = config.GetConnectionString("V2Ray");
                    string[] hostInfo = host.Split(':');
                    Channel channel = new Channel(hostInfo[0], hostInfo.Length > 1 ? Convert.ToInt32(hostInfo[1]) : 80, ChannelCredentials.Insecure);
                    StatsService.StatsServiceClient client = new StatsService.StatsServiceClient(channel);
                    return client;
                });
                services.AddSingleton<IV2RayCollectService, V2RayCollectService>();
                services.AddHostedService<TimeBasedService>();
            });
            builder.Build().Run();
        }
    }
}
