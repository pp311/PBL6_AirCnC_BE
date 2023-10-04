using AirCnC.Application.Services.Auth.Dtos;
using AirCnC.Application.Services.PropertyService.Dtos;
using AirCnC.Domain.Entities;
using AutoMapper;

namespace AirCnC.Application.MappingProfile;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<User, GetUserDto>();
        CreateMap<Property, GetPropertyDto>();
        CreateMap<PropertyImage, GetPropertyImageDto>();
    } 
}