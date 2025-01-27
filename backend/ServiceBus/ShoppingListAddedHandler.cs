using Application;

namespace ServiceBus
{
    public class ShoppingListAddedHandler : IHandleMessages<ShoppingListAddedMessage>
    {
        public Task Handle(ShoppingListAddedMessage message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received message: {message.Message}");
            return Task.CompletedTask;
        }
    }
}
