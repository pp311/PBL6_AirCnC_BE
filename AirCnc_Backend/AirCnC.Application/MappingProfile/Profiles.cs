using AirCnC.Application.Services.Auth.Dtos;
using AirCnC.Application.Services.Bookings.Dtos;
using AirCnC.Application.Services.Guests.Dtos;
using AirCnC.Application.Services.Hosts.Dtos;
using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Application.Services.Wishlists.Dtos;
using AirCnC.Domain.Entities;
using AutoMapper;

namespace AirCnC.Application.MappingProfile;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<User, GetUserDto>();

        CreateMap<Host, GetHostDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(h => h.User.FullName))
            .ForMember(dto => dto.Introduction, opt => opt.MapFrom(h => h.User.Introduction))
            .ForMember(dto => dto.AvatarUrl, opt => opt.MapFrom(h => h.User.AvatarUrl))
            .ForMember(dto => dto.Address, opt => opt.MapFrom(h => h.User.Address))
            .ForMember(dto => dto.City, opt => opt.MapFrom(h => h.User.City))
            .ForMember(dto => dto.JoinedAt, opt => opt.MapFrom(h => h.CreatedAt));
        
        CreateMap<Guest, GetGuestDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(h => h.User.FullName))
            .ForMember(dto => dto.Introduction, opt => opt.MapFrom(h => h.User.Introduction))
            .ForMember(dto => dto.AvatarUrl, opt => opt.MapFrom(h => h.User.AvatarUrl))
            .ForMember(dto => dto.Address, opt => opt.MapFrom(h => h.User.Address))
            .ForMember(dto => dto.City, opt => opt.MapFrom(h => h.User.City))
            .ForMember(dto => dto.JoinedAt, opt => opt.MapFrom(h => h.CreatedAt));
        
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
            .ForMember(dto => dto.NumberOfDays, opt => opt.MapFrom(b => b.CheckOutDate.Subtract(b.CheckInDate).Days))
            .ForMember(dto => dto.CheckInCode, opt => opt.MapFrom(b => b.Guid));
        
        CreateMap<Booking, GetDraftBookingDto>()
            .ForMember(dto => dto.PropertyName, opt => opt.MapFrom(b => b.Property.Title))
            .ForMember(dto => dto.NumberOfDays, opt => opt.MapFrom(b => b.CheckOutDate.Subtract(b.CheckInDate).Days));

        CreateMap<Booking, GetBookingForPropertyDto>();
        CreateMap<CreateBookingDto, Booking>();
        CreateMap<VnpHistoryDto, VnpHistory>();
        CreateMap<VnpHistory, VnpHistoryDto>();

        CreateMap<Wishlist, WishlistsDto>();
    } 
}