namespace AirCnC.Application.Services.Reviews.Dtos;

public class PropertyReviewInfoDto
{
    public double Cleanliness { get; set; }
    public double Accuracy { get; set; }
    public double Communication { get; set; }
    public double CheckIn { get; set; }
    public double Value { get; set; }
    public double Location { get; set; }
    
    public int NumberOfReviews { get; set; }
}