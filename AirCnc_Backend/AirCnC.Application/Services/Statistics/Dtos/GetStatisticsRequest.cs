namespace AirCnC.Application.Services.Statistics.Dtos;

public class GetStatisticsRequest
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}