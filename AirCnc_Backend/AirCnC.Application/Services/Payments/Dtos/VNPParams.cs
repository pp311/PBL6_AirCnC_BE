using AirCnC.Application.Commons;

namespace AirCnC.Application.Services.Payments.Dtos;

public class VNPParams : PagingParameters
{
    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }
}