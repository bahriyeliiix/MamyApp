using AutoMapper;
using MamyApp.Core.Entities;  
using MamyApp.Application.DTOs;
using MamyApp.Application.Dtos;
using MamyApp.Application.Features.Users.Commands;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();

        CreateMap<CreateUserDto, User>();    
        CreateMap<User, CreateUserDto>();    
        
        CreateMap<CreateUserCommand, CreateUserDto>();
        CreateMap<CreateUserDto, CreateUserCommand>();

        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserCommand>();
    }
}
