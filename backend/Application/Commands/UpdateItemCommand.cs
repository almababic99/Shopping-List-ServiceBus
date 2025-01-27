using MediatR;

namespace Application.Commands
{
    public class UpdateItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
