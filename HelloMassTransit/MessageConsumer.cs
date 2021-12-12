using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace HelloMassTransit
{
    public class MessageConsumer : IConsumer<Message>
    {
        private readonly ILogger<MessageConsumer> logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            logger.LogInformation("Received Text: {Text}", context.Message.Text);

            return Task.CompletedTask;
        }
    }
}