using AirCnC.Application.Services.Auth.Dtos;
using AirCnC.Application.Services.BookingService.Dtos;
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
        CreateMap<PropertyUtility, GetPropertyUtilityDto>();
        CreateMap<UpsertPropertyDto,Property>();
        CreateMap<UpsertPropertyImageDto, PropertyImage>();
        CreateMap<PropertyUtilityDto, PropertyUtility>();

        CreateMap<Booking, GetBookingForHostDto>()
            .ForMember(dto => dto.GuestName, opt => opt.MapFrom(b => b.Guest.User.FullName))
            .ForMember(dto => dto.GuestEmail, opt => opt.MapFrom(b => b.Guest.User.Email))
            .ForMember(dto => dto.GuestPhoneNumber, opt => opt.MapFrom(b => b.Guest.User.PhoneNumber))
            .ForMember(dto => dto.PropertyName, opt => opt.MapFrom(b => b.Property.Title))
            .ForMember(dto => dto.NumberOfDays, opt => opt.MapFrom(b => b.CheckOutDate.Subtract(b.CheckInDate).Days));
        
        CreateMap<Booking, GetBookingForGuestDto>()
            .ForMember(dto => dto.HostName, opt => opt.MapFrom(b => b.Property.Host.User.FullName))
            .ForMember(dto => dto.HostEmail, opt => opt.MapFrom(b => b.Property.Host.User.Email))
            .ForMember(dto => dto.HostPhoneNumber, opt => opt.MapFrom(b => b.Property.Host.User.PhoneNumber))
            .ForMember(dto => dto.PropertyName, opt => opt.MapFrom(b => b.Property.Title))
            .ForMember(dto => dto.NumberOfDays, opt => opt.MapFrom(b => b.CheckOutDate.Subtract(b.CheckInDate).Days));
        
        CreateMap<Booking, GetDraftBookingDto>()
            .ForMember(dto => dto.PropertyName, opt => opt.MapFrom(b => b.Property.Title))
            .ForMember(dto => dto.NumberOfDays, opt => opt.MapFrom(b => b.CheckOutDate.Subtract(b.CheckInDate).Days));

        CreateMap<Booking, GetBookingForPropertyDto>();
        CreateMap<CreateBookingDto, Booking>();
    } 
}