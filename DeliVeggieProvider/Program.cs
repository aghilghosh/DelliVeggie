using DeliVeggieProvider;
using DeliVeggieProvider.Infrastructure.Abstraction;
using DeliVeggieProvider.Infrastructure.Implementations;
using DeliVeggiieShared.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configuration = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .AddJsonFile("appsettings.json")
        .Build();

IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
{
    services.AddHostedService<Worker>();
    services.AddSingleton<IResponseHandler, ResponseHandler>();
    services.AddSingleton<IDataContext, DataContext>();
    services.AddSingleton<IInventoryRepository, InventoryRepository>();
    services.Configure<RabbitMqConfig>(configuration.GetSection("RabbitMqConfig"));
    services.Configure<DbConfig>(configuration.GetSection("DbConfig"));
}).Build();

await host.RunAsync();
