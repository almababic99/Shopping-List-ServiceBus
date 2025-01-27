using Application.Interfaces;
using Domain.DomainModels;
using MediatR;

namespace Application.Commands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IEndpointInstance _endpointInstance;

        public CreateItemCommandHandler(IItemRepository itemRepository, IEndpointInstance endpointInstance)
        {
            _itemRepository = itemRepository;
            _endpointInstance = endpointInstance;
        }

        public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item { Id = request.Id, Name = request.Name };  // mapping dto to domain

            var existingItem = await _itemRepository.GetItem(item.Name);

            if (existingItem != null)
            {
                throw new InvalidOperationException("An item with the same name already exists");  // if the name already exists it throws an error
            }

            await _itemRepository.AddItem(item).ConfigureAwait(false);

            var message = new ItemAddedMessage
            {
                Message = "New item is added!"
            };

            Console.WriteLine($"Sending message: {message.Message}");
            await _endpointInstance.Send("ServiceBus", message);
        }
    }
}
