using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace HelloMassTransit
{
    public class Worker : BackgroundService
    {
        private readonly IBus bus;

        public Worker(IBus bus)
        {
            this.bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now}" });
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}