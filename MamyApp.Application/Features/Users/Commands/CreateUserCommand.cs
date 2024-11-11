using MediatR;

namespace MamyApp.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
