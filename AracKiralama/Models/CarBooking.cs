
namespace AracKiralama.Models
{
    public class CarBooking
    {
        public string Id { get; set; } = string.Empty;

        public string CarId { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public List<string> ExtraIds { get; set; } = new();

        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; }
    }
}
