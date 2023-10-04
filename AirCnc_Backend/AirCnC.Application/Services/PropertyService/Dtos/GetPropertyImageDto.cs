namespace AirCnC.Application.Services.PropertyService.Dtos
{
    public class GetPropertyImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int PropertyId { get; set; }
    }
}
