public class CarBooking
{
    public string Id { get; set; } = "";
    public string CarId { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public List<string> ExtraIds { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }

    public string? CarImageUrl { get; set; }
    public string? CarBrandModel { get; set; }
}