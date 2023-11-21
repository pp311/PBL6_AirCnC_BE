using AirCnC.Application.Commons;

namespace AirCnC.Application.Services.Users.Dtos;

public class UserPagingParameters : PagingParameters
{
    public bool IsHostOnly { get; set; } 
}