using Application;

namespace ServiceBus
{
    public class ShopperAddedHandler : IHandleMessages<ShopperAddedMessage>
    {
        public Task Handle(ShopperAddedMessage message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received message: {message.Message}");
            return Task.CompletedTask;
        }
    }
}
