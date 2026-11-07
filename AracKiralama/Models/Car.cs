
namespace AracKiralama.Models
{
    public class Car
    {
        public string Id { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string FuelType { get; set; } = string.Empty;

        public string Transmission { get; set; } = string.Empty;

        public int Seats { get; set; }

        public decimal DailyPrice { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
        
    }
}
