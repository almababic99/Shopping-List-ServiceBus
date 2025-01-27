using Application;

namespace ServiceBus
{
    public class ItemAddedHandler : IHandleMessages<ItemAddedMessage>
    {
        public Task Handle(ItemAddedMessage message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received message: {message.Message}");
            return Task.CompletedTask;
        }
    }
}
