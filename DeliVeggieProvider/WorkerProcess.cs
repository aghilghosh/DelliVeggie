using DeliVeggieProvider.Infrastructure.Abstraction;
using DeliVeggiieShared.Models;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DeliVeggieProvider
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        private readonly IHost _host;
        private readonly ILogger<Worker> _logger;

        public Worker(IOptions<RabbitMqConfig> options, ILogger<Worker> logger, IHost host)
        {
            _host = host;
            _bus = RabbitHutch.CreateBus(options.Value.ConnectionString);
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var requestHandler = _host.Services.GetService<IResponseHandler>();

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Worker running at: {DateTimeOffset.Now}");
                await _bus.Rpc.RespondAsync<IRequest, IResponse>(requestHandler.HandleRequest);
            }
        }
    }
}
