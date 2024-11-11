using MediatR;
using MamyApp.Core.Entities;
using MamyApp.Core.Interfaces;
using MamyApp.Application.DTOs;
using AutoMapper;

namespace MamyApp.Application.Features.Users.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            return _mapper.Map<UserDto>(user);
        }
    }
}
