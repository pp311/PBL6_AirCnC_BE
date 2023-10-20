namespace AirCnC.Application.Services.Properties.Dtos
{
    public class GetPropertyImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int PropertyId { get; set; }
    }
}
