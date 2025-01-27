using Application.Interfaces;
using Domain.DomainModels;
using MediatR;

namespace Application.Commands
{
    public class CreateShopperCommandHandler : IRequestHandler<CreateShopperCommand>
    {
        private readonly IShopperRepository _shopperRepository;
        private readonly IEndpointInstance _endpointInstance;

        public CreateShopperCommandHandler(IShopperRepository shopperRepository, IEndpointInstance endpointInstance)
        {
            _shopperRepository = shopperRepository;
            _endpointInstance = endpointInstance;
        }

        public async Task Handle(CreateShopperCommand request, CancellationToken cancellationToken)
        {
            var shopper = new Shopper { Id = request.Id, Name = request.Name };   // mapping dto to domain

            var existingShopper = await _shopperRepository.GetShopper(shopper.Name);

            if (existingShopper != null)
            {
                throw new InvalidOperationException("Shopper with the same name already exists");  // if the name already exists it throws an error
            }

            await _shopperRepository.AddShopper(shopper);

            var message = new ShopperAddedMessage
            {
                Message = "New shopper is added!"
            };

            Console.WriteLine($"Sending message: {message.Message}");
            await _endpointInstance.Send("ServiceBus", message);
        }
    }
}
