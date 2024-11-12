using MediatR;

namespace MamyApp.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
