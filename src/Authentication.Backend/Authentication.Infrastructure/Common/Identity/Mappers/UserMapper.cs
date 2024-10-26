using Authentication.Application.Common.Identity.Models;
using Authentication.Domain.Entities;
using AutoMapper;

namespace Authentication.Infrastructure.Common.Identity.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
