using MediatR;
using MamyApp.Core.Entities;
using MamyApp.Application.DTOs;

namespace MamyApp.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
