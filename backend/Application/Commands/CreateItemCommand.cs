using MediatR;

namespace Application.Commands
{
    public class CreateItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
