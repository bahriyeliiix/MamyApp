using AutoMapper;
using MamyApp.Core.Entities;  
using MamyApp.Application.DTOs;
using MamyApp.Application.Dtos; 

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();     
    }
}
