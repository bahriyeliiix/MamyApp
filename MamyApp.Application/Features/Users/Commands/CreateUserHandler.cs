using MediatR;
using MamyApp.Core.Entities;
using MamyApp.Core.Interfaces;
using AutoMapper;

namespace MamyApp.Application.Features.Users.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);

                await _userRepository.AddAsync(user);
                return user.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }
    }
}
